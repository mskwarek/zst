using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZST
{
    class Server
    {
        private TcpListener serverSocket;
        private Thread serverThread;
        private Dictionary<TcpClient, string> clientSockets;
        private ASCIIEncoding encoder;
        private bool running = false;

        public delegate void LogMsgHandler(object myObject, LogArgs myArgs);
        public event LogMsgHandler OnNewLogRecived;

        public Server()
        {
            clientSockets = new Dictionary<TcpClient, string>();
            this.encoder = new ASCIIEncoding();
        }

        public bool startServer(string port)
        {
            int runningPort = Convert.ToInt32(port);
            if (serverSocket == null && serverThread == null)
            {
                this.serverSocket = new TcpListener(IPAddress.Any, runningPort);
                running = true;
                this.serverThread = new Thread(new ThreadStart(ListenForClients));
                this.serverThread.Start();
                return true;
            }

            else
            {
                return false;
            }
        }

        public void stopServer()
        {
            running = false;
        }

        private void ListenForClients()
        {
            this.serverSocket.Start();
            while (true)
            {
                try
                {
                    TcpClient clientSocket = this.serverSocket.AcceptTcpClient();
                    clientSockets.Add(clientSocket, "unknown");
                    Thread clientThread = new Thread(new ParameterizedThreadStart(displayMessageReceived));
                    clientThread.Start(clientSocket);
                }
                catch
                {
                    break;
                }
            }
        }

        private void displayMessageReceived(object client)
        {
            TcpClient clientSocket = (TcpClient)client;
            NetworkStream stream = clientSocket.GetStream();

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

                string signal = encoder.GetString(message, 0, bytesRead);
                Console.WriteLine(signal);
                if (clientSockets[clientSocket].Equals("unknown"))
                {
                    updateClientName(clientSocket, signal); //clients as first message send his id
                    string msg = "connection OK" + "&";
                    sendMessage(clientSockets[clientSocket], msg);
                 
                }
                else
                {
                    string[] elem = signal.Split('&');
                    //LogAgent.addLog(elem);


                    LogArgs myArgs = new LogArgs(elem);
                    OnNewLogRecived(this, myArgs);


                }
            }
            if (serverSocket != null)
            {
                try
                {
                    clientSocket.GetStream().Close();
                    clientSocket.Close();
                    clientSockets.Remove(clientSocket);
                }
                catch
                {
                }
            }
        }
        public void sendMessage(string name, string msg)
        {
            for (int i = 0; i < clientSockets.Count; i++)
            {
                Console.WriteLine("nazwy clientow " + clientSockets.ElementAt(i).Value.ToString());
            }


            if (serverSocket != null)
            {
                NetworkStream stream = null;
                TcpClient client = getTcpClient(name);



                if (client != null)
                {
                    if (client.Connected)
                    {
                        stream = client.GetStream();
                        byte[] buffer = encoder.GetBytes(msg);
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();
                    }
                    else
                    {
                        stream.Close();
                        clientSockets.Remove(client);
                    }
                }
            }
        }

        private void updateClientName(TcpClient client, string signal)
        {
            if (signal.Contains("//NAME// "))
            {
                string[] tmp = signal.Split(' ');
                clientSockets[client] = tmp[1];
            }
        }


        private TcpClient getTcpClient(string name)
        {
            TcpClient client = null;
            List<TcpClient> clientsList = clientSockets.Keys.ToList();
            for (int i = 0; i < clientsList.Count; i++)
            {
                if (clientSockets[clientsList[i]].Equals(name))
                {
                    client = clientsList[i];
                    return client;
                }
            }
            return null;
        }

    }
}
