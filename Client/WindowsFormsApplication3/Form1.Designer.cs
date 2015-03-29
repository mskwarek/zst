namespace WindowsFormsApplication3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.logMsgTextBox = new System.Windows.Forms.TextBox();
            this.sendMsgButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logMsgTextBox
            // 
            this.logMsgTextBox.Location = new System.Drawing.Point(12, 188);
            this.logMsgTextBox.Name = "logMsgTextBox";
            this.logMsgTextBox.Size = new System.Drawing.Size(260, 20);
            this.logMsgTextBox.TabIndex = 0;
            this.logMsgTextBox.Text = "Log Message";
            this.logMsgTextBox.TextChanged += new System.EventHandler(this.logMsgTextBox_TextChanged);
            // 
            // sendMsgButton
            // 
            this.sendMsgButton.Location = new System.Drawing.Point(12, 214);
            this.sendMsgButton.Name = "sendMsgButton";
            this.sendMsgButton.Size = new System.Drawing.Size(260, 35);
            this.sendMsgButton.TabIndex = 1;
            this.sendMsgButton.Text = "Send Log";
            this.sendMsgButton.UseVisualStyleBackColor = true;
            this.sendMsgButton.Click += new System.EventHandler(this.sendMsgButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(260, 35);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.sendMsgButton);
            this.Controls.Add(this.logMsgTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logMsgTextBox;
        private System.Windows.Forms.Button sendMsgButton;
        private System.Windows.Forms.Button connectButton;
    }
}

