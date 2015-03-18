using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace ZST
{
    public partial class Form1 : Form
    {
        private LogAgent logAgent;
        

        public Form1()
        {
            InitializeComponent();
            logAgent = new LogAgent(this.logListView);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            logAgent.loadLogs(openFileDialog.FileName);
            //enableButtonAfterConfiguration();
            //electionAuthority = new ElectionAuthority(this.logs, this.configuration, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //logAgent.Path = openFileDialog.FileName;
            
            this.logAgent.saveLogsToFile(openFileDialog1.FileName);
            Console.WriteLine(openFileDialog1.FileName);
            MessageBox.Show("XML File created ! ");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            logAgent.clearList(logListView);
            logListView.Items.Clear();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    logAgent.stopServer();
                    Process.GetCurrentProcess().Kill();
                    break;
            }
        }  
    }
}
