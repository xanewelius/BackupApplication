﻿namespace BackupApplication
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.backUpAppDBDataSet = new BackupApplication.BackUpAppDBDataSet();
            this.backUpGoogleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backUpGoogleTableAdapter = new BackupApplication.BackUpAppDBDataSetTableAdapters.BackUpGoogleTableAdapter();
            this.googleIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backupDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backUpAppDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backUpGoogleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.googleIDDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.backupDateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.backUpGoogleBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(447, 175);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Место для загрузки";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(366, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 4;
            this.button2.Text = "Загрузить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // backUpAppDBDataSet
            // 
            this.backUpAppDBDataSet.DataSetName = "BackUpAppDBDataSet";
            this.backUpAppDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // backUpGoogleBindingSource
            // 
            this.backUpGoogleBindingSource.DataMember = "BackUpGoogle";
            this.backUpGoogleBindingSource.DataSource = this.backUpAppDBDataSet;
            // 
            // backUpGoogleTableAdapter
            // 
            this.backUpGoogleTableAdapter.ClearBeforeFill = true;
            // 
            // googleIDDataGridViewTextBoxColumn
            // 
            this.googleIDDataGridViewTextBoxColumn.DataPropertyName = "GoogleID";
            this.googleIDDataGridViewTextBoxColumn.HeaderText = "GoogleID";
            this.googleIDDataGridViewTextBoxColumn.Name = "googleIDDataGridViewTextBoxColumn";
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            // 
            // backupDateDataGridViewTextBoxColumn
            // 
            this.backupDateDataGridViewTextBoxColumn.DataPropertyName = "BackupDate";
            this.backupDateDataGridViewTextBoxColumn.HeaderText = "BackupDate";
            this.backupDateDataGridViewTextBoxColumn.Name = "backupDateDataGridViewTextBoxColumn";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 254);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загрузка с Google Disk";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backUpAppDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backUpGoogleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private BackUpAppDBDataSet backUpAppDBDataSet;
        private System.Windows.Forms.BindingSource backUpGoogleBindingSource;
        private BackUpAppDBDataSetTableAdapters.BackUpGoogleTableAdapter backUpGoogleTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn googleIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backupDateDataGridViewTextBoxColumn;
    }
}