using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ZST
{
    /// <summary>
    /// Klasa reprezentująca pojedyńczy log (zapis w dzienniku zdarzen)
    /// </summary>
    class Log
    {
        /// <summary>
        /// informacje przechowywane w 4 rozmiarowej tablicy stringów
        /// </summary>
        string[] info = new string[4];
        public enum logType { Warning, Minor, Major, Critical, Cleared, Indeterminate };
        logType type;

        public logType Type
        {
            get {return type;}
            set {type = value;}
        }
        /// <summary>
        /// Pobieranie i ustawianie daty
        /// </summary>
        public string Date
        {
            get { return info[0]; }
            set { info[0] = value; }
        }

        /// <summary>
        /// pobieranie i ustawianie czasu
        /// </summary>
        public string Time
        {
            get { return info[1]; }
            set { info[1] = value; }
        }

        /// <summary>
        /// pobieranie i ustawianie źródła od którego pochodzi zapis w dzienniku
        /// </summary>
        public string Source
        {
            get { return info[2]; }
            set { info[2] = value; }
        }

        /// <summary>
        /// pobieranie i ustawianie tekstu wiadomości
        /// </summary>
        public string Msg
        {
            get { return info[3]; }
            set { info[3] = value; }
        }

        /// <summary>
        /// Konstruktor klasy Log
        /// </summary>
        /// <param name="node">węzeł z pliku xml zawierający informacje o Logu</param>
        public Log(XmlNode node)
        {
            info[0] = node.SelectSingleNode("Date").InnerText;
            info[1] = node.SelectSingleNode("Time").InnerText;
            info[2] = node.SelectSingleNode("Source").InnerText;
            info[3] = node.SelectSingleNode("LogMessage").InnerText;
            type = (logType)Convert.ToInt32(node.SelectSingleNode("Type").InnerText);
        }

        /// <summary>
        /// Konstruktor klasy Log
        /// </summary>
        /// <param name="msg">tekst wiadomości z jaką chcemy utworzyć zapis</param>
        public Log(string[] msg)
        {
            info[0] = msg[0];
            info[1] = msg[1];
            info[2] = msg[2];
            info[3] = msg[3];
            type = (logType)Convert.ToInt32(msg[4]);

        }

        /// <summary>
        /// pobieranie informacji o całym zapisie w dzienniku
        /// </summary>
        /// <returns>informacje o Log</returns>
        public string[] getLog(){
            return info;
        }

        /// <summary>
        /// Zapisanie pojedyńczego Logu jako węzła XMLowego
        /// </summary>
        /// <param name="writer">XML gdzie należy zapisać Log</param>
        public void createNode(XmlTextWriter writer)
        {
            writer.WriteStartElement("data");
            writer.WriteStartElement("Date");
            writer.WriteString(this.info[0]);
            writer.WriteEndElement();
            writer.WriteStartElement("Time");
            writer.WriteString(this.info[1]);
            writer.WriteEndElement();
            writer.WriteStartElement("Source");
            writer.WriteString(this.info[2]);
            writer.WriteEndElement();
            writer.WriteStartElement("LogMessage");
            writer.WriteString(this.info[3]);
            writer.WriteEndElement();
            writer.WriteStartElement("Type");
            writer.WriteString(Convert.ToString((int)this.type));
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
