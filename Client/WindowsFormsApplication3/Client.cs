using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    class Client
    {
        private ASCIIEncoding encoder;
        private TcpClient client;
        private NetworkStream stream;
        private Thread clientThread;


        public Client()
        {
            this.encoder = new ASCIIEncoding();

        }


        public bool connect(string ip, string port)
        {

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
                clientThread = new Thread(new ThreadStart(displayMessageReceived));
                clientThread.Start();
                sendMyName();
               
                return true;
            }
            else
            {
                client = null;
                
                return false;
            }
        }

        private void sendMyName()
        {
            {
                byte[] buffer = encoder.GetBytes("//NAME// " + "PROXY");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }

        private void displayMessageReceived()
        {
            byte[] message = new byte[4096];
            int bytesRead;

            while (stream.CanRead)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }
                string strMessage = encoder.GetString(message, 0, bytesRead);
                //this.parserEA.parseMessageFromEA(strMessage);
            }
            if (client != null)
            {
                disconnect(true);
            }
        }

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
                    //logs.addLog(Constants.CONNECTION_DISCONNECTED, true, Constants.LOG_INFO, true);
                }
                else
                {
                    //logs.addLog(Constants.CONNECTION_DISCONNECTED_ERROR, true, Constants.LOG_ERROR, true);
                    //form.Invoke(new MethodInvoker(delegate() { form.buttonsEnabled(); }));
                }
            }
        }

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
