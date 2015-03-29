using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZST
{
    /// <summary>
    /// Klasa argumentów wysyłanego zdarzenia (przyjścia nowego logu z sieci)
    /// </summary>
    class LogArgs : EventArgs
    {
        /// <summary>
        /// tablica przechuwająca niesioną wiadomość
        /// </summary>
        private string[] message;

        /// <summary>
        /// Konstruktor zdarzenia na podstawie niesionej wiadomości
        /// </summary>
        /// <param name="message"></param>
        public LogArgs(string[] message)
        {
            this.message = message;
        }

        /// <summary>
        /// pobieranie informacji o zdarzeniu
        /// </summary>
        public string[] Message
        {
            get
            {
                return message;
            }
        }
    }
}
