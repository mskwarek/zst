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
using BrightIdeasSoftware;

namespace ZST
{
    /// <summary>
    /// Klasa reprezentująca okienko aplikacji
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// instancja klasy logAgent
        /// </summary>
        private LogAgent logAgent;

        /// <summary>
        /// Lista zaznaczonych logów, używana do późniejszego odpowiedniego usunięcia 
        /// (na życzenie użytkownika)
        /// </summary>
        private List<int> selected;
        
        /// <summary>
        /// Konstruktor klasy okienka aplikacji
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            selected = new List<int>();
            logAgent = new LogAgent(this.objectListView1);
            
        }

        /// <summary>
        /// metoda uruchamiana po wciśnięciu 1. przycisku (czytanie logów)
        /// </summary>
        /// <param name="sender">obiekt wysyłający zdarzenie</param>
        /// <param name="e">wysyłane zdarzenie</param>
        private void button1_Click(object sender, EventArgs e)
        {  
            openFileDialog.ShowDialog();
        }

        /// <summary>
        /// Metoda uruchamiana po wybraniu pliku
        /// </summary>
        /// <param name="sender">obiekt wysyłający zdarzenie</param>
        /// <param name="e">wysyłane zdarzenie</param>
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            logAgent.loadLogs(openFileDialog.FileName);
        }

        /// <summary>
        /// metoda uruchamiana po wciśnięciu 2. przycisku (zapis logów do pliku)
        /// </summary>
        /// <param name="sender">obiekt wysyłający zdarzenie</param>
        /// <param name="e">wysyłane zdarzenie</param>
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
        }

        /// <summary>
        /// metoda wywoływana po wybraniu miejsca zapisu logów
        /// </summary>
        /// <param name="sender">obiekt wysyłający zdarzenie</param>
        /// <param name="e">wysyłane zdarzenie</param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.logAgent.saveLogsToFile(openFileDialog1.FileName);
            Console.WriteLine(openFileDialog1.FileName);
            MessageBox.Show("XML File created ! ");
        }

        /// <summary>
        /// Przeciążona metoda wywoływana na skutek próbu zamknięcia okienka
        /// </summary>
        /// <param name="e">otrzymane zdarzenie</param>
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

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// metoda wywoływana przy próbie usunięcia logów z listy
        /// </summary>
        /// <param name="sender">obiekt wysyłający zdarzenie</param>
        /// <param name="e">wysyłane zdarzenie</param>
        private void button3_Click(object sender, EventArgs e)
        {
            selected.Clear();
            foreach (Object selectedObj in this.objectListView1.SelectedObjects)
            {
                selected.Add(this.objectListView1.IndexOf(selectedObj));
            }
            this.logAgent.removeLogs(selected);
            this.objectListView1.RemoveObjects(this.objectListView1.SelectedObjects);
            
        }  
    }
}
