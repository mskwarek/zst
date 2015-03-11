namespace ZST
{
    partial class Form1
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
            this.logListView = new System.Windows.Forms.ListView();
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // logListView
            // 
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.date,
            this.time,
            this.source,
            this.logMessage});
            this.logListView.Location = new System.Drawing.Point(12, 12);
            this.logListView.Name = "logListView";
            this.logListView.Size = new System.Drawing.Size(719, 414);
            this.logListView.TabIndex = 1;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.View = System.Windows.Forms.View.Details;
            // 
            // date
            // 
            this.date.Text = "Date";
            this.date.Width = 104;
            // 
            // time
            // 
            this.time.Text = "Time";
            this.time.Width = 98;
            // 
            // source
            // 
            this.source.Text = "Source";
            this.source.Width = 134;
            // 
            // logMessage
            // 
            this.logMessage.Text = "Log Message";
            this.logMessage.Width = 326;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(740, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Read Logs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 438);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logListView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader source;
        private System.Windows.Forms.ColumnHeader logMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

