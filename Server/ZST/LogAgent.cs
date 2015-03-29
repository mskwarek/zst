using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ZST
{
    /// <summary>
    /// Klasa pozwalająca na zdalny zapis logów
    /// </summary>
    class LogAgent
    {
        /// <summary>
        /// Lista przechowywanych logów
        /// </summary>
        static List<Log> logs = new List<Log>();

        /// <summary>
        /// Instancja Klasy serwera
        /// </summary>
        private Server server;

        /// <summary>
        /// Instancja klasy wyświetlającej logi na ekranie
        /// </summary>
        private LogViewer logViewer;

        /// <summary>
        /// Konstruktor klasy LogAgent
        /// </summary>
        /// <param name="objlv">Object List View - miejsce wyświetlania logów</param>
        public LogAgent(ObjectListView objlv)
        {
            logViewer = new LogViewer(objlv);
            List<String> config = new List<String>();
            config = readConfig();
            server = new Server();
            server.OnNewLogRecived += new Server.LogMsgHandler(updateList);
            server.startServer(config[0]);
        }

        /// <summary>
        /// Metoda wczytująca dane konfiguracyjne z pliku
        /// </summary>
        /// <returns>listę stringów określających konfigurację aplikacji</returns>
        private List<String> readConfig()
        {
            XmlDocument xml = new XmlDocument();
            
            var filePath = System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\Resources\\Config.xml";
            Console.WriteLine(filePath);
            xml.Load(filePath);

            List<String> list = new List<String>();

            foreach (XmlNode xnode in xml.SelectNodes("//Config[@serverPort]"))
            {
                string serverPort = xnode.Attributes[0].Value;
                list.Add(serverPort);
                string serverIP= xnode.Attributes[1].Value;
                list.Add(serverIP);
            }

            return list;
        }

        /// <summary>
        /// wczytywanie Logów z pliku
        /// </summary>
        /// <param name="path">ścieżka do pliku</param>
        /// <returns>wynik (udany, nieudany zapis do pliku)</returns>
        public bool loadLogs(string path)
        {
            XmlDocument xml = new XmlDocument();

            try
            {
                xml.Load(path);
                logs = logs.Concat(readLogs(xml)).ToList();

                string[] filePath = path.Split('\\');
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return false;
            }
        }

        /// <summary>
        /// Wczytywanie logów z xmla
        /// </summary>
        /// <param name="xml">konkretny dokument XML</param>
        /// <returns>Listę logów</returns>
        private List<Log> readLogs(XmlDocument xml)
        {
            List<Log> list = new List<Log>();
            XmlNodeList nodeList = xml.DocumentElement.SelectNodes("/Table/data");

            foreach (XmlNode xnode in nodeList)
            {
                Log log = new Log(xnode);
                this.logViewer.updateLogList(log, list);
            }
            return list;
        }

        /// <summary>
        /// zapis logów do pliku
        /// </summary>
        /// <param name="path">ścieżka do pliku</param>
        public void saveLogsToFile(string path)
        {
            XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;

            writer.WriteStartElement("Table");

            try
            {
                foreach (Log log in logs)
                {
                    log.createNode(writer);
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ex loading file" + ex.Message);
            }
        }

        /// <summary>
        /// Usuwanie Logów
        /// </summary>
        /// <param name="toRemove">Lista indeksów logów do usunięcia</param>
        public void removeLogs(List<int> toRemove)
        {
            toRemove.Sort();
            for (int i = toRemove.Count - 1; i >= 0; i--)
            {
                logs.RemoveAt(toRemove[i]);
            }
        }

        /// <summary>
        /// Odświeżanie listy wyświetlanych logów (na skutek odebrania nowego Loga)
        /// </summary>
        /// <param name="a">obiekt wysyłający zdarzenie</param>
        /// <param name="e">wysylane zdarzenie</param>
        private void updateList(object a, LogArgs e)
        {
            Log log = new Log(e.Message);
            this.logViewer.updateLogList(log, logs);
        }

        /// <summary>
        /// Zatrzymanie działania serwera (zwolnienie zasobów)
        /// </summary>
        public void stopServer()
        {
            server.stopServer();
        }
    }
}
