﻿namespace BackupApplication
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ghjkkgjhjkhlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jhbkhjkbhjkbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backupHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backUpAppDBDataSet = new BackupApplication.BackUpAppDBDataSet();
            this.backupHistoryTableAdapter = new BackupApplication.BackUpAppDBDataSetTableAdapters.BackupHistoryTableAdapter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backUpAppDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 66);
            this.button1.TabIndex = 0;
            this.button1.Text = "Резервировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 66);
            this.button2.TabIndex = 1;
            this.button2.Text = "Загрузить с Google Disk";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 372);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(224, 66);
            this.button3.TabIndex = 3;
            this.button3.Text = "Удалить с реестра";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 346);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ключ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ghjkkgjhjkhlToolStripMenuItem,
            this.jhbkhjkbhjkbToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(895, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ghjkkgjhjkhlToolStripMenuItem
            // 
            this.ghjkkgjhjkhlToolStripMenuItem.Name = "ghjkkgjhjkhlToolStripMenuItem";
            this.ghjkkgjhjkhlToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.ghjkkgjhjkhlToolStripMenuItem.Text = "Обновить";
            this.ghjkkgjhjkhlToolStripMenuItem.Click += new System.EventHandler(this.ghjkkgjhjkhlToolStripMenuItem_Click);
            // 
            // jhbkhjkbhjkbToolStripMenuItem
            // 
            this.jhbkhjkbhjkbToolStripMenuItem.Name = "jhbkhjkbhjkbToolStripMenuItem";
            this.jhbkhjkbhjkbToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.jhbkhjkbhjkbToolStripMenuItem.Text = "О приложении";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(243, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(638, 410);
            this.dataGridView1.TabIndex = 7;
            // 
            // backupHistoryBindingSource
            // 
            this.backupHistoryBindingSource.DataMember = "BackupHistory";
            this.backupHistoryBindingSource.DataSource = this.backUpAppDBDataSet;
            // 
            // backUpAppDBDataSet
            // 
            this.backUpAppDBDataSet.DataSetName = "BackUpAppDBDataSet";
            this.backUpAppDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // backupHistoryTableAdapter
            // 
            this.backupHistoryTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(895, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backUpAppDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ghjkkgjhjkhlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jhbkhjkbhjkbToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BackUpAppDBDataSet backUpAppDBDataSet;
        private System.Windows.Forms.BindingSource backupHistoryBindingSource;
        private BackUpAppDBDataSetTableAdapters.BackupHistoryTableAdapter backupHistoryTableAdapter;
    }
}

