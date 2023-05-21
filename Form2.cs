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

namespace BackupApplication
{
    public partial class Form2 : Form
    {

        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BackUpAppDB.accdb";
        private OleDbConnection myconnect = new OleDbConnection(connectionString);
        
        string sourceFolder = ""; // Путь к исходной папке
        string targetFolder = ""; // Путь к целевой папке
        string zipFilePath = "";
        string sourceFolderPath = "";
        string googleDriveFolderId = "15Bslce3Fpqzg3DiG73xOEIHwZ251FHeI";
        string currentDate = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss)"); // Форматирование текущей даты и времени

        public Form2()
        {
            InitializeComponent();
        }

        private static void SaveZipToGoogleDrive(string zipFilePath, string googleDriveFolderId)
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
                Console.WriteLine("File ID: " + file.Id);
                MessageBox.Show("Резервное копирование на локальный накопитель выполнено успешно.");
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
                // Создание ZIP-файла
                ZipFile.CreateFromDirectory(sourceFolderPath, zipFilePath);

                MessageBox.Show("ZIP-файл успешно создан и сохранен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании ZIP-файла: " + ex.Message);
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
            saveFileDialog.FileName = "backup_" + DateTime.Now.ToString("yyyyMMddHHmmss"); // Генерация имени файла с использованием текущей даты и времени
            saveFileDialog.Filter = "ZIP Archive|*.zip";
            DialogResult saveResult = saveFileDialog.ShowDialog();
            if (saveResult == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                textBox2.Text = saveFileDialog.FileName; // Установите полный путь к файлу в текстовом поле
                zipFilePath = saveFileDialog.FileName; // Сохраните полный путь к файлу в переменной
            }
            else
            {
                textBox2.Text = ""; // Очистите текстовое поле, если файл не был выбран
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool saveToDatabase = checkBox1.Checked; // Флаг сохранения в базу данных
            bool saveLocally = checkBox2.Checked; // Флаг сохранения локально
            //string zipFileName = "backup_" + currentDate + ".zip"; // Имя zip-файла с добавленной датой и временем
            //string zipFilePath = Path.Combine(targetFolder, zipFileName); // Путь к создаваемому zip-файлу

            if (saveLocally)
            {
                SaveZipLocally(sourceFolderPath, zipFilePath);
            }

            if (saveToDatabase)
            {
                SaveZipToGoogleDrive(zipFilePath, googleDriveFolderId);
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
    }
}
