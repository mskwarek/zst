using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApplication3
{
    /// <summary>
    /// Klasa klienta
    /// </summary>
    class Client
    {
        /// <summary>
        /// Użyty enkoder do odkodowywania/zakodowywania wiadomości
        /// </summary>
        private ASCIIEncoding encoder;

        /// <summary>
        /// Klient TCP
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// strumeń siociowy
        /// </summary>
        private NetworkStream stream;

        /// <summary>
        /// Lista konfiguracyjna
        /// </summary>
        private List<String> conf;

        /// <summary>
        /// Konstruktor klasy klienta
        /// </summary>
        public Client()
        {
            this.encoder = new ASCIIEncoding();
            conf = readConfig();

        }

        /// <summary>
        /// metoda odczytująca konfigurację klienta
        /// </summary>
        /// <returns>listę konfiguracyjną (port, IP serwera)</returns>
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
                string serverIP = xnode.Attributes[1].Value;
                list.Add(serverIP);
            }
            return list;
        }

        /// <summary>
        /// metoda łącząca klienta z serwerem
        /// </summary>
        /// <returns>wynik operacji (powodzenia/niepowodzenie)</returns>
        public bool connect()
        {
            string ip = conf[1];
            string port = conf[0];

            client = new TcpClient();
            IPAddress ipAddress;
            if (ip.Contains("localhost"))
            {
                ipAddress = IPAddress.Loopback;
            }
            else
            {
                ipAddress = IPAddress.Parse(ip);
            }

            try
            {
                int dstPort = Convert.ToInt32(port);
                client.Connect(new IPEndPoint(ipAddress, dstPort));
            }
            catch { }

            if (client.Connected)
            {
                stream = client.GetStream();
                sendMyName();
               
                return true;
            }
            else
            {
                client = null;
                
                return false;
            }
        }

        /// <summary>
        /// Metoda wysyłająca identyfikator klienta do serwera
        /// </summary>
        private void sendMyName()
        {
            {
                byte[] buffer = encoder.GetBytes("//NAME// " + "PROXY");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }

        /// <summary>
        /// Rozłączenie klienta z serwerem
        /// </summary>
        /// <param name="error">parametr określający czy rozłączenie wystąpiło z powodu błędu</param>
        public void disconnect(bool error = false)
        {
            if (client != null)
            {
                try
                {
                    client.GetStream().Close();
                    client.Close();
                    client = null;
                }
                catch (Exception)
                {
                    Console.WriteLine("Problem with disconnecting");
                }
                if (!error)
                {

                }
                else
                {

                }
            }
        }

        /// <summary>
        /// Wysyłanie wiadomości
        /// </summary>
        /// <param name="msg">wiadomość do wysłania</param>
        public void sendMessage(string msg)
        {
            if (client != null && client.Connected && msg != "")
            {
                msg = DateTime.Now.ToString("y-M-d") + "&" + DateTime.Now.ToString("HH:mm:ss") + "&" + LocalIPAddress() + "&" + msg;
                byte[] buffer = encoder.GetBytes(msg);
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }

        /// <summary>
        /// Pobieranie lokalnego adresu IP komputera
        /// </summary>
        /// <returns>IP klienta</returns>
        private string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

    }
}
