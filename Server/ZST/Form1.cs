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

namespace ZST
{
    public partial class Form1 : Form
    {
        private LogAgent conf;
        

        public Form1()
        {
            InitializeComponent();
            conf = new LogAgent(this.logListView);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            conf.loadLogs(openFileDialog.FileName);
            //enableButtonAfterConfiguration();
            //electionAuthority = new ElectionAuthority(this.logs, this.configuration, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            conf.Path = openFileDialog.FileName;
            this.conf.saveLogsToFile();
            MessageBox.Show("XML File created ! ");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            conf.clearList(logListView);
            logListView.Items.Clear();
        }
    }
}
