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
        public static string connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BackUpAppDB.accdb";
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "backUpAppDBDataSet.BackupHistory". При необходимости она может быть перемещена или удалена.
            this.backupHistoryTableAdapter.Fill(this.backUpAppDBDataSet.BackupHistory);
        }

        private void ghjkkgjhjkhlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.backupHistoryTableAdapter.Update(this.backUpAppDBDataSet.BackupHistory);
        }
    }
}
