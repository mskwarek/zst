using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        private Client client;
        public Form1()
        {
            InitializeComponent();
            client = new Client();
            this.sendMsgButton.Enabled = false;
        }

        private void logMsgTextBox_TextChanged(object sender, EventArgs e)
        {
            this.sendMsgButton.Enabled = true;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            client.connect();
        }

        private void sendMsgButton_Click(object sender, EventArgs e)
        {
            this.client.sendMessage(this.logMsgTextBox.Text);
        }
    }
}
