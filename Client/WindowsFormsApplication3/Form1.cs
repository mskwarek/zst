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
    /// <summary>
    /// Klasa reprezentująca okno aplikacji
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// instancja klasy klienta
        /// </summary>
        private Client client;

        /// <summary>
        /// Konstruktor klasy form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            client = new Client();
            this.sendMsgButton.Enabled = false;
        }

        /// <summary>
        /// Reakcja programu na zmianę tekstu w text boxie
        /// </summary>
        /// <param name="sender">obiekt wysyłający zdarzenie</param>
        /// <param name="e">wysyłane zdarzenie</param>
        private void logMsgTextBox_TextChanged(object sender, EventArgs e)
        {
            this.sendMsgButton.Enabled = true;
        }
        
        /// <summary>
        /// Metoda wykonująca się na skutek wciśnięcia przycisku połączenia z serwerem
        /// </summary>
        /// <param name="sender">obiekt wysyłający zdarzenie</param>
        /// <param name="e">wysyłane zdarzenie</param>
        private void connectButton_Click(object sender, EventArgs e)
        {
            client.connect();
        }

        /// <summary>
        /// Metoda wykonująca się na skutek wciśnięcia przycisku wysyłania wiadomości do serwera
        /// </summary>
        /// <param name="sender">obiekt wysyłający zdarzenie</param>
        /// <param name="e">wysyłane zdarzenie</param>
        private void sendMsgButton_Click(object sender, EventArgs e)
        {
            this.client.sendMessage(this.logMsgTextBox.Text);
        }
    }
}
