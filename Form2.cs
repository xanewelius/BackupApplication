using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.Remoting.Contexts;

namespace BackupApplication
{
    public partial class Form2 : Form
    {

        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BackUpAppDB.accdb";
        private OleDbConnection myconnect = new OleDbConnection(connectionString);
        

        string sourceFolder = ""; // Путь к исходной папке
        string targetFolder = ""; // Путь к целевой папке
        string currentDate = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss)"); // Форматирование текущей даты и времени

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath; // Set the full file path in the textbox
                sourceFolder = dialog.SelectedPath; // Save the full file path in the variable
            }
            else
            {
                textBox1.Text = ""; // Clear the textbox if no file was selected
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dialog.SelectedPath; // Set the full file path in the textbox
                sourceFolder = dialog.SelectedPath; // Save the full file path in the variable
            }
            else
            {
                textBox2.Text = ""; // Clear the textbox if no file was selected
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool saveToDatabase = checkBox1.Checked; // Флаг сохранения в базу данных
            bool saveLocally = checkBox2.Checked; // Флаг сохранения локально

            if (saveLocally)
            {
                if (string.IsNullOrEmpty(targetFolder))
                {
                    MessageBox.Show("Пожалуйста, выберите целевую папку.");
                    return;
                }

                string zipFileName = "backup_" + currentDate + ".zip"; // Имя zip-файла с добавленной датой и временем
                string zipFilePath = Path.Combine(targetFolder, zipFileName); // Путь к создаваемому zip-файлу

                try
                {
                    ZipFile.CreateFromDirectory(sourceFolder, zipFilePath, CompressionLevel.Optimal, true);
                    MessageBox.Show("Резервное копирование на локальный накопитель выполнено успешно.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении резервного копирования: " + ex.Message);
                }
            }

            if (saveToDatabase)
            {
                if (string.IsNullOrEmpty(sourceFolder))
                {
                    MessageBox.Show("Пожалуйста, выберите целевую папку.");
                    return;
                }
                string checkboxValue = saveLocally ? "Database, locale" : "Database"; // Указывает как сохранялось
                string zipFileName = "backup_" + currentDate + ".zip"; // Имя zip-файла с добавленной датой и временем
                string zipFilePath = Path.Combine(sourceFolder, zipFileName); // Путь к создаваемому zip-файлу
                ZipFile.CreateFromDirectory("C:\\Users\\slkip\\Desktop\\bac", zipFilePath, CompressionLevel.Optimal, true);

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Чтение содержимого файла в массив байтов
                    byte[] fileBytes = File.ReadAllBytes(zipFilePath);

                    // Создание SQL-запроса с параметрами
                    string query = "INSERT INTO BackupHistory (FileName, BackupDate, BackupPath, BackupType, BackupFile) " +
                        "VALUES (?, ?, ?, ?, ?)";
                    try
                    {
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            // Добавление параметров
                            command.Parameters.AddWithValue("FileName", Path.GetFileName(zipFilePath));
                            command.Parameters.AddWithValue("BackupDate", "12/12/2022");
                            command.Parameters.AddWithValue("BackupPath", "path_to_backup_folder");
                            command.Parameters.AddWithValue("BackupType", checkboxValue);
                            command.Parameters.AddWithValue("BackupFile", zipFilePath);

                            // Выполнение запроса
                            command.ExecuteNonQuery();
                            MessageBox.Show("Резервное копирование на локальный накопитель выполнено успешно.");
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при выполнении резервного копирования: " + ex.Message);
                    }
                }
            }
            //MessageBox.Show("Операции завершены.");
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
                textBox2.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = true; // Установка значения по умолчанию для checkBox1
        }
    }
}
