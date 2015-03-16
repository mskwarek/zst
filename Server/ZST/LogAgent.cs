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
        private ListView logListView;
        private string path;

        public LogAgent(ListView logs)
        {
            this.logListView = logs;
        }

        private List<Log> readLogs(XmlDocument xml)
        {

            List<Log> list = new List<Log>();
            ListViewItem item = new ListViewItem();
            item.ForeColor = Color.Blue;
            XmlNodeList nodeList = xml.DocumentElement.SelectNodes("/Table/data");

            foreach (XmlNode xnode in nodeList)
            {      
                Log log = new Log(xnode);
                list.Add(log);
                var listViewItem = new ListViewItem(log.getLog());
                logListView.Items.Add(listViewItem);
            }

            return list;

        }

        public bool loadLogs(string path)
        {
            this.path = path;

            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(path);       
                logs = readLogs(xml);


                string[] filePath = path.Split('\\');
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return false;
            }
        }

        public static void addLog(string[] msg)
        {

            logs.Add(new Log(msg));
        }

        public void saveLogsToFile()
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
                MessageBox.Show("XML File created ! ");
            }
            catch(Exception ex)
            {
                MessageBox.Show("ex loading file" + ex.Message);
            }
            
        }
    }
}
