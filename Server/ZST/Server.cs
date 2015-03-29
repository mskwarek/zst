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
    /// <summary>
    /// Klasa serwera
    /// </summary>
    class Server
    {
        /// <summary>
        /// Socket na którym słucha instancja danej klasy
        /// </summary>
        private TcpListener serverSocket;

        /// <summary>
        /// Wątek klasy serwera
        /// </summary>
        private Thread serverThread;

        /// <summary>
        /// Słownik parujący klienta TCP z jego identyfikatorem
        /// </summary>
        private Dictionary<TcpClient, string> clientSockets;

        /// <summary>
        /// Użyty encoder, do odkodowania przesyłanych wiadomości
        /// </summary>
        private ASCIIEncoding encoder;

        /// <summary>
        /// zmienna pomocnicza do obsługi wątka serwera
        /// </summary>
        private bool running = false;

        /// <summary>
        /// Obiekt obsługujący zdarzenie nadejścia nowego Logu
        /// </summary>
        /// <param name="myObject">obiekt wysyłający zdarzenie</param>
        /// <param name="myArgs">wysyłane zdarzenie</param>
        public delegate void LogMsgHandler(object myObject, LogArgs myArgs);

        /// <summary>
        /// zdarzenie otrzymania nowego Logu
        /// </summary>
        public event LogMsgHandler OnNewLogRecived;

        /// <summary>
        /// Konstruktor klasy serwera
        /// </summary>
        public Server()
        {
            clientSockets = new Dictionary<TcpClient, string>();
            this.encoder = new ASCIIEncoding();
        }

        /// <summary>
        /// Metoda startująca serwer
        /// </summary>
        /// <param name="port">port na którym serwer ma pracować</param>
        /// <returns>wynik operacji (udana/nieudana)</returns>
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

        /// <summary>
        /// zatrzymanie działania serwera
        /// </summary>
        public void stopServer()
        {
            running = false;
        }

        /// <summary>
        /// Oczekiwanie na połączenie klientów
        /// </summary>
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

        /// <summary>
        /// Wyświetlanie otrzymanej wiadomości
        /// </summary>
        /// <param name="client">Klient od którego otrzymanow wiadomość</param>
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
                }
                else
                {
                    string[] elem = signal.Split('&');
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

        /// <summary>
        /// Odświeżanie identyfikatorów klientów
        /// </summary>
        /// <param name="client">Klient</param>
        /// <param name="signal">otrzymany sygnał</param>
        private void updateClientName(TcpClient client, string signal)
        {
            if (signal.Contains("//NAME// "))
            {
                string[] tmp = signal.Split(' ');
                clientSockets[client] = tmp[1];
            }
        }
    }
}
