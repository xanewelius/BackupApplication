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

namespace BackupApplication
{
    public partial class Form1 : Form
    {
        public static string connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BackUpAppDataBase.accdb";
        private OleDbConnection myconnect;
        OleDbCommand command;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
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
                    // Строка подключения к базе данных Microsoft Access
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BackUpAppDataBase.accdb";

                    // SQL-запрос на удаление записи по идентификатору
                    string query = "DELETE FROM BackUpHistory WHERE id = @Id";

                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        // Открываем соединение с базой данных
                        connection.Open();

                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            // Параметр запроса
                            command.Parameters.AddWithValue("@Id", textBox1.Text);

                            // Выполняем запрос
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Удаление прошло успешно!");
                    Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удаление данных: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "backUpAppDataBaseDataSet.BackUpHistory". При необходимости она может быть перемещена или удалена.
            this.backUpHistoryTableAdapter.Fill(this.backUpAppDataBaseDataSet.BackUpHistory);
        }

        private void Update()
        {
            this.backUpHistoryTableAdapter.Update(this.backUpAppDataBaseDataSet.BackUpHistory);
            this.backUpHistoryTableAdapter.Fill(this.backUpAppDataBaseDataSet.BackUpHistory);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 AboutBox = new AboutBox1();
            AboutBox.ShowDialog();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update();
        }
    }
}
