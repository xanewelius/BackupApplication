using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupApplication
{
    public partial class Form3 : Form
    {
        string destinationPath = "";
        public Form3()
        {
            InitializeComponent();
        }

        //Кнопка folder
        private void button1_Click(object sender, EventArgs e)
        {
            var sourceFolderDialog = new FolderBrowserDialog();
            DialogResult result = sourceFolderDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(sourceFolderDialog.SelectedPath))
            {
                textBox1.Text = sourceFolderDialog.SelectedPath; // Установите полный путь к папке в текстовом поле
                destinationPath = sourceFolderDialog.SelectedPath; // Сохраните полный путь к папке в переменной
            }
            else
            {
                textBox1.Text = ""; // Очистите текстовое поле, если папка не была выбрана
            }
        }

        //Кнопка загрузки
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Пожалуйста, заполните текстовое поле.");
            }
            else
            {
                int index;
                string fileId;
                index = dataGridView1.CurrentRow.Index;
                fileId = dataGridView1[0, index].Value.ToString();
                //string fileId = kod;
                //string fileId = "1BTXo_7Yy33PBoKOKCBlpwuL3h3pIr31o";
                DownloadFileFromGoogleDrive(fileId, destinationPath);
            }
        }

        private static void DownloadFileFromGoogleDrive(string fileId, string destinationPath)
        {
            UserCredential credential;

            try
            {

                using (var stream = new FileStream("X:\\gradwork\\BackupApplication\\client_secret_305646777020-5n13elsb83g3n7oanut1m1cksrrrkej5.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "path_to_store_token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { DriveService.Scope.DriveReadonly },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Your Application Name",
                });

                var fileRequest = service.Files.Get(fileId);
                var file = fileRequest.Execute();

                destinationPath = Path.Combine(destinationPath, file.Name);

                using (var fileStream = new FileStream(destinationPath, FileMode.Create))
                {
                    var request = service.Files.Get(fileId);
                    request.Download(fileStream);
                }
                MessageBox.Show("Загрузка с Google Disk выполнена успешно!");
            } 

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении загрузки: " + ex.Message);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "backUpAppDataBaseDataSet.BackUpGoogle". При необходимости она может быть перемещена или удалена.
            this.backUpGoogleTableAdapter.Fill(this.backUpAppDataBaseDataSet.BackUpGoogle);
        }
    }
}
