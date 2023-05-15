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

namespace BackupApplication
{
    public partial class Form2 : Form
    {
        string sourceFolder = ""; // Путь к исходной папке
        string targetFolder = ""; // Путь к целевой папке

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
                sourceFolder = textBox1.Text; // Путь к исходной папке
            }
            else { textBox1.Text = ""; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = dialog.SelectedPath;
                targetFolder = textBox2.Text; // Путь к целевой папке
            }
            else { textBox2.Text = ""; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool saveToDatabase = checkBox1.Checked; // Флаг сохранения в базу данных
            bool saveLocally = checkBox2.Checked; // Флаг сохранения локально

            if (saveToDatabase)
            {
                string zipFilePath = Path.Combine(targetFolder, "backup.zip"); // Путь к создаваемому zip-файлу

                // Код для сохранения в базу данных
                // Используйте вашу логику для добавления zip-файла в базу данных
            }

            if (saveLocally)
            {
                if (string.IsNullOrEmpty(targetFolder))
                {
                    MessageBox.Show("Пожалуйста, выберите целевую папку.");
                    return;
                }

                string currentDate = DateTime.Now.ToString("yyyy-MM-dd_HH-mm"); // Форматирование текущей даты и времени
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

            //MessageBox.Show("Операции завершены.");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                checkBox2.Checked = true; // Установка значения по умолчанию для checkBox2
            }

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
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                checkBox1.Checked = true; // Установка значения по умолчанию для checkBox1
            }
        }
    }
}
