using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Data.OleDb;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Security.AccessControl;

namespace BackupApplication
{
    public partial class Form2 : Form
    {
        private System.Timers.Timer timer;
        // Строка подключения к базе данных Microsoft Access
        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BackUpAppDataBase.accdb";
        
        string currentDate = "";
        string zipFilePath = "";
        string sourceFolderPath = "";
        string zipFileName = "";
        string zipFilePathAuto = "";
        string googleDriveFolderId = "";
        string GoogleFileID = "";
        bool isBackupCompleted = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void SaveZipToGoogleDrive(string sourceFolderPath, string zipFilePath, string googleDriveFolderId)
        {
            UserCredential credential;

            try
            {
                using (var stream = new FileStream("X:\\gradwork\\BackupApplication\\client_secret_305646777020-5n13elsb83g3n7oanut1m1cksrrrkej5.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "path_to_store_token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        clientSecrets: GoogleClientSecrets.Load(stream).Secrets,
                        scopes: new[] { DriveService.Scope.Drive },
                        user: "user",
                        taskCancellationToken: CancellationToken.None,
                        dataStore: new FileDataStore(credPath, true)).Result;
                }

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Your Application Name",
                });

                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(zipFilePath),
                    MimeType = "application/zip",
                    Parents = new List<string> { googleDriveFolderId } // ID папки на Google Диске, куда нужно сохранить файл
                };

                FilesResource.CreateMediaUpload request;
                using (var stream = new FileStream(zipFilePath, FileMode.Open))
                {
                    request = service.Files.Create(fileMetadata, stream, "application/zip");
                    request.Upload();
                }

                var file = request.ResponseBody;
                GoogleFileID = file.Id;
                Console.WriteLine("File ID: " + file.Id);
                if (!isBackupCompleted)
                {
                    isBackupCompleted = true;
                    MessageBox.Show("Резервное копирование на Google Disk выполнено успешно.");
                    AddGoogleFileData(zipFileName, GoogleFileID);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении резервного копирования: " + ex.Message);
            }
        }

        private void SaveZipLocally(string sourceFolderPath, string zipFilePath)
        {
            try
            {
                currentDate = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                zipFileName = "backup_" + currentDate + ".zip"; // Имя zip-файла с добавленной датой и временем
                zipFilePath = Path.Combine(zipFilePath, zipFileName); // Путь к создаваемому zip-файлу
                zipFilePathAuto = zipFilePath;
                // Создание ZIP-файла
                ZipFile.CreateFromDirectory(sourceFolderPath, zipFilePath);

                MessageBox.Show("ZIP-файл успешно создан и сохранен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании ZIP-файла: " + ex.Message);
            }
        }

        // Метод для добавления данных о файле в базу данных Microsoft Access. Таблица - BackUpGoogle
        public void AddFileData(string fileName, string FirstBackupPath, string SecondBackupPath, string GoogleID)
        {
            // SQL-запрос на добавление данных о файле
            string query = "INSERT INTO BackUpHistory (FileName, BackupDate, FirstBackupPath, SecondBackupPath, GoogleID) VALUES (@FileName, @BackupDate, @FirstBackupPath, @SecondBackupPath, @GoogleID)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Открываем соединение с базой данных
                connection.Open();

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Параметры запроса
                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@BackupDate", currentDate);
                    command.Parameters.AddWithValue("@FirstBackupPath", FirstBackupPath);
                    command.Parameters.AddWithValue("@SecondBackupPath", SecondBackupPath);
                    command.Parameters.AddWithValue("@GoogleID", GoogleID);
                    // Выполняем запрос
                    command.ExecuteNonQuery();
                }
            }
        }

        // Метод для добавления данных о файле в базу данных Microsoft Access. Таблица - BackUpHistory
        public void AddGoogleFileData(string fileName, string GoogleID)
        {
            // SQL-запрос на добавление данных о файле
            string query = "INSERT INTO BackUpGoogle (GoogleID, BackUpName, BackUpDate) VALUES (@GoogleID, @BackUpName, @BackUpDate)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Открываем соединение с базой данных
                connection.Open();

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Параметры запроса
                    command.Parameters.AddWithValue("@GoogleID", GoogleID);
                    command.Parameters.AddWithValue("@BackUpName", fileName);
                    command.Parameters.AddWithValue("@BackUpDate", currentDate);
                    // Выполняем запрос
                    command.ExecuteNonQuery();
                }
            }
        }

        // Первый текстбокс
        // Отображение диалога выбора исходной папки
        private void button1_Click(object sender, EventArgs e)
        {
            var sourceFolderDialog = new FolderBrowserDialog();
            DialogResult result = sourceFolderDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(sourceFolderDialog.SelectedPath))
            {
                textBox1.Text = sourceFolderDialog.SelectedPath; // Установите полный путь к папке в текстовом поле
                sourceFolderPath = sourceFolderDialog.SelectedPath; // Сохраните полный путь к папке в переменной
            }
            else
            {
                textBox1.Text = ""; // Очистите текстовое поле, если папка не была выбрана
            }
        }

        // Второй текстбокс
        // Отображение диалога выбора пути сохранения ZIP-файла
        private void button2_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "backup_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"); // Генерация имени файла с использованием текущей даты и времени
            saveFileDialog.Filter = "ZIP Archive|*.zip";
            //zipFileName = saveFileDialog.FileName;
            DialogResult saveResult = saveFileDialog.ShowDialog();
            if (saveResult == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                string selectedFilePath = saveFileDialog.FileName;
                string directoryPath = Path.GetDirectoryName(selectedFilePath); // Получите только путь к директории без имени файла
                textBox2.Text = directoryPath; // Установите полный путь к директории в текстовом поле
                zipFilePath = directoryPath;
            }
            else
            {
                textBox2.Text = ""; // Очистите текстовое поле, если файл не был выбран
            }
        }

        public void AutoTimerGoogleDrive(int min)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 6000; // Интервал в миллисекундах (здесь 60 минут)
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            bool saveToDatabase = checkBox1.Checked; // Флаг сохранения в базу данных
            bool saveLocally = checkBox2.Checked; // Флаг сохранения локально

            if (saveToDatabase)
            {
                SaveZipToGoogleDrive(sourceFolderPath, zipFilePathAuto, googleDriveFolderId);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            bool saveToDatabase = checkBox1.Checked; // Флаг сохранения в базу данных
            bool saveLocally = checkBox2.Checked; // Флаг сохранения локально
            bool autoSave = checkBox3.Checked; // Флаг на автосохранение
            googleDriveFolderId = textBox3.Text; // 15Bslce3Fpqzg3DiG73xOEIHwZ251FHeI
            int min = 11;

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все текстовые поля");
            }
            else
            {
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"); // Форматирование текущей даты и времени
                //zipFileName = "backup_" + currentDate + ".zip"; // Имя zip-файла с добавленной датой и временем
                //zipFilePath = Path.Combine(targetFolder, zipFileName); // Путь к создаваемому zip-файлу

                if (saveLocally)
                {
                    if (autoSave)
                    {
                        SaveZipLocally(sourceFolderPath, zipFilePath);
                    }
                    else
                    {
                        SaveZipLocally(sourceFolderPath, zipFilePath);
                    }
                }
                
                if (saveToDatabase)
                {
                    if (string.IsNullOrEmpty(textBox3.Text))
                    {
                        MessageBox.Show("Пожалуйста, заполните все текстовые поля");
                    }
                    if (autoSave)
                    {
                        if (min <= 10)
                        {
                            MessageBox.Show("Пожалуйста, введите значение больше 10");
                        }
                        else
                        {
                            AutoTimerGoogleDrive(min);
                        }
                        
                    }
                    else
                    {
                        SaveZipToGoogleDrive(sourceFolderPath, zipFilePathAuto, googleDriveFolderId);
                    }
                }
                AddFileData(zipFileName, sourceFolderPath, zipFilePath, GoogleFileID);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = true;
                button2.Enabled = true;
            }
            checkBox2.Checked = true; // Установка значения по умолчанию для checkBox1
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked || checkBox4.Checked)
            {
                textBox4.Enabled = true;
            }
            else
            {
                textBox4.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked || checkBox3.Checked)
            {
                textBox4.Enabled = true;
            }
            else
            {
                textBox4.Enabled = false;
            }
        }
    }
}
