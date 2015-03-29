using BrightIdeasSoftware;
using System;
using System.Drawing;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.dt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tm = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.src = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.msg = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 390);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 390);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Write Logs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.dt);
            this.objectListView1.AllColumns.Add(this.tm);
            this.objectListView1.AllColumns.Add(this.src);
            this.objectListView1.AllColumns.Add(this.msg);
            this.objectListView1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dt,
            this.tm,
            this.src,
            this.msg});
            this.objectListView1.Location = new System.Drawing.Point(12, 12);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(726, 372);
            this.objectListView1.TabIndex = 5;
            this.objectListView1.UseCellFormatEvents = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            // 
            // dt
            // 
            this.dt.AspectName = "Date";
            this.dt.IsEditable = false;
            this.dt.Text = "Date";
            this.dt.Width = 93;
            // 
            // tm
            // 
            this.tm.AspectName = "Time";
            this.tm.IsEditable = false;
            this.tm.Text = "Time";
            this.tm.Width = 108;
            // 
            // src
            // 
            this.src.AspectName = "Source";
            this.src.Text = "Source";
            this.src.Width = 77;
            // 
            // msg
            // 
            this.msg.AspectName = "Msg";
            this.msg.Text = "Log Message";
            this.msg.Width = 198;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(585, 390);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 36);
            this.button3.TabIndex = 6;
            this.button3.Text = "Remove Selected Logs";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 451);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Server";
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }





        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn dt;
        private BrightIdeasSoftware.OLVColumn tm;
        private BrightIdeasSoftware.OLVColumn src;
        private BrightIdeasSoftware.OLVColumn msg;
        private System.Windows.Forms.Button button3;
       
  
    }
}

