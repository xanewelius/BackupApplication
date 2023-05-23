namespace BackupApplication
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
            this.googleIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backUpNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backUpDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backUpGoogleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backUpAppDataBaseDataSet = new BackupApplication.BackUpAppDataBaseDataSet();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.backUpGoogleTableAdapter = new BackupApplication.BackUpAppDataBaseDataSetTableAdapters.BackUpGoogleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backUpGoogleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backUpAppDataBaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.googleIDDataGridViewTextBoxColumn,
            this.backUpNameDataGridViewTextBoxColumn,
            this.backUpDateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.backUpGoogleBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(376, 175);
            this.dataGridView1.TabIndex = 0;
            // 
            // googleIDDataGridViewTextBoxColumn
            // 
            this.googleIDDataGridViewTextBoxColumn.DataPropertyName = "GoogleID";
            this.googleIDDataGridViewTextBoxColumn.HeaderText = "GoogleID";
            this.googleIDDataGridViewTextBoxColumn.Name = "googleIDDataGridViewTextBoxColumn";
            // 
            // backUpNameDataGridViewTextBoxColumn
            // 
            this.backUpNameDataGridViewTextBoxColumn.DataPropertyName = "BackUpName";
            this.backUpNameDataGridViewTextBoxColumn.HeaderText = "BackUpName";
            this.backUpNameDataGridViewTextBoxColumn.Name = "backUpNameDataGridViewTextBoxColumn";
            // 
            // backUpDateDataGridViewTextBoxColumn
            // 
            this.backUpDateDataGridViewTextBoxColumn.DataPropertyName = "BackUpDate";
            this.backUpDateDataGridViewTextBoxColumn.HeaderText = "BackUpDate";
            this.backUpDateDataGridViewTextBoxColumn.Name = "backUpDateDataGridViewTextBoxColumn";
            // 
            // backUpGoogleBindingSource
            // 
            this.backUpGoogleBindingSource.DataMember = "BackUpGoogle";
            this.backUpGoogleBindingSource.DataSource = this.backUpAppDataBaseDataSet;
            // 
            // backUpAppDataBaseDataSet
            // 
            this.backUpAppDataBaseDataSet.DataSetName = "BackUpAppDataBaseDataSet";
            this.backUpAppDataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.button2.Location = new System.Drawing.Point(295, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 4;
            this.button2.Text = "Загрузить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // backUpGoogleTableAdapter
            // 
            this.backUpGoogleTableAdapter.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 254);
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
            ((System.ComponentModel.ISupportInitialize)(this.backUpGoogleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backUpAppDataBaseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private BackUpAppDataBaseDataSet backUpAppDataBaseDataSet;
        private System.Windows.Forms.BindingSource backUpGoogleBindingSource;
        private BackUpAppDataBaseDataSetTableAdapters.BackUpGoogleTableAdapter backUpGoogleTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn googleIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backUpNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backUpDateDataGridViewTextBoxColumn;
    }
}