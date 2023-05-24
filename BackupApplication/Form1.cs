using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BackupApplication
{
    public partial class Form1 : Form
    {
        // Строка подключения к базе данных Microsoft Access
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BackUpAppDataBase.accdb";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show(); // Show для того, чтобы можно было свернуть вкладку а не все приложение
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        //Удаление
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Пожалуйста, заполните текстовое поле.");
            }
            else
            {
                try
                {
                    int fileIdToDelete = Convert.ToInt32(textBox1.Text);

                    // SQL-запрос на удаление записи по идентификатору
                    string deleteQuery = "DELETE FROM BackUpHistory WHERE IDProc = @IDProc";
                    string selectQuery = "SELECT FileName, SecondBackupPath FROM BackUpHistory WHERE IDProc = @IDProc";

                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        // Открываем соединение с базой данных
                        connection.Open();

                        // Получаем имя файла из базы данных
                        string fileName = string.Empty;
                        string filePath = string.Empty;
                        using (OleDbCommand selectCommand = new OleDbCommand(selectQuery, connection))
                        {
                            selectCommand.Parameters.AddWithValue("@IDProc", fileIdToDelete);
                            using (OleDbDataReader reader = selectCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    fileName = reader["FileName"].ToString();
                                    filePath = reader["SecondBackupPath"].ToString();
                                }
                            }
                        }

                        using (OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, connection))
                        {
                            // Параметр запроса
                            deleteCommand.Parameters.AddWithValue("@IDProc", fileIdToDelete);

                            // Выполняем запрос на удаление записи
                            deleteCommand.ExecuteNonQuery();
                        }

                        // Проверяем, есть ли имя файла
                        if (!string.IsNullOrEmpty(fileName))
                        {
                            string endFilePath = Path.Combine(filePath, fileName); // Соединяем имя файла с путем до файла

                            // Удаляем файл из системы
                            File.Delete(endFilePath);
                        }

                        // После удаления данных, загружаем обновленные данные из базы данных в DataGridView
                        string selectAllQuery = "SELECT * FROM BackUpHistory";
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectAllQuery, connection))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                    MessageBox.Show("Удаление прошло успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении данных: " + ex.Message);
                }
            }
            RefreshDataGridView();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "backUpAppDataBaseDataSet.BackUpHistory". При необходимости она может быть перемещена или удалена.
            this.backUpHistoryTableAdapter.Fill(this.backUpAppDataBaseDataSet.BackUpHistory);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 AboutBox = new AboutBox1();
            AboutBox.ShowDialog();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        public void RefreshDataGridView()
        {
            // Обновляем данные в DataGridView
            string selectAllQuery = "SELECT * FROM BackUpHistory";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectAllQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}
