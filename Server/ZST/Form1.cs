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
        private Server server;

        public Form1()
        {
            InitializeComponent();
            conf = new LogAgent(this.logListView);
            server = new Server();
            server.startServer("3333");
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
            this.conf.saveLogsToFile();
        }
    }
}
