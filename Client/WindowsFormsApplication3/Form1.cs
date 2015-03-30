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
        /// flaga reprezentująca moment wyboru jednego z rodzajów zdarzenia
        /// </summary>
        private bool ComboBoxFlag = false;

        /// <summary>
        /// flaga reprezentująca fakt wpisania tekstu wiadomości
        /// </summary>
        private bool MsgBoxFlag = false;

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
            if (ComboBoxFlag)
            {
                this.sendMsgButton.Enabled = true;
            }

            else
            {
                MsgBoxFlag = true;
            }

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
            this.client.sendMessage(this.logMsgTextBox.Text+ "&" + this.comboBox1.SelectedIndex);
        }

        /// <summary>
        /// Metoda wykonująca się na skutek wyboru indeksu z comboBoxa
        /// </summary>
        /// <param name="sender">obiekt wysyłajacy zdarzenie</param>
        /// <param name="e">wysyłane zdarzenie</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MsgBoxFlag)
            {
                this.sendMsgButton.Enabled = true;
            }
            else
            {
                ComboBoxFlag = true;
            }
        }
    }
}
