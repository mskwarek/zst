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
    class Log
    {
        string[] info = new string[4];

        public Log(XmlNode node)
        {
            info[0] = node.SelectSingleNode("Date").InnerText;
            info[1] = node.SelectSingleNode("Time").InnerText;
            info[2] = node.SelectSingleNode("Source").InnerText;
            info[3] = node.SelectSingleNode("LogMessage").InnerText;
        }

        public Log(string[] msg)
        {
            info = msg;
        }

        public string[] getLog(){
            return info;
        }

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
            writer.WriteEndElement();
        }
    }
}
