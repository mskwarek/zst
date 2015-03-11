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
    class Config
    {

        List<Log> logs = new List<Log>();
        private ListView logListView;

        public Config(ListView logs)
        {
            this.logListView = logs;
        }

        private List<Log> readLogs(XmlDocument xml)
        {

            List<Log> list = new List<Log>();
            ListViewItem item = new ListViewItem();
            item.ForeColor = Color.Blue;

            foreach (XmlNode xnode in xml.SelectNodes("//Date[@ID]"))
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
    }
}
