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
    class LogAgent
    {

        static List<Log> logs = new List<Log>();

        private ObjectListView objlv;
        private string path;
        private Server server;

        public LogAgent(ObjectListView objlv)
        {
            //this.objlv = logs;
            this.objlv = objlv;

            List<String> config = new List<String>();
            config = readConfig();
            server = new Server();
            server.OnNewLogRecived += new Server.LogMsgHandler(updateList);
            server.startServer(config[0]);

        }

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

        private List<Log> readLogs(XmlDocument xml)
        {
            List<Log> list = new List<Log>();
            
            XmlNodeList nodeList = xml.DocumentElement.SelectNodes("/Table/data");

            foreach (XmlNode xnode in nodeList)
            {
                Log log = new Log(xnode);
                this.updateLogList(log, list);
            }

            return list;

        }

        private void updateList(object a, LogArgs e)
        {

            Log log = new Log(e.Message);
            this.updateLogList(log, logs);
        }

        private void updateLogList(Log log, List<Log> list, bool anotherThread = true)
        {
            

            if (!anotherThread)
            {
                list.Add(log);
                var listViewItem = new ListViewItem(log.getLog());
                
                this.objlv.AddObject(log);
            }
            else
            {
                objlv.Invoke(new MethodInvoker(delegate()
                {
                    list.Add(log);
                    var listViewItem = new ListViewItem(log.getLog());
                    this.objlv.AddObject(log);})
                    );
            }
        }
        public bool loadLogs(string path)
        {
            this.path = path;
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
            catch(Exception ex)
            {
                MessageBox.Show("ex loading file" + ex.Message);
            }
            
        }

        public void removeLogs(List<int> toRemove)
        {
            toRemove.Sort();
            for(int i = toRemove.Count-1; i>=0; i--)
            {
                logs.RemoveAt(toRemove[i]);
            }

        }

        public void stopServer()
        {
            server.stopServer();
        }
    }
}
