using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ZST
{
    class Log
    {
        private DateTime date;
        private string source;
        private string message;

        string[] info = new string[4];

        public Log(XmlNode node)
        {
            string readDate = node.Attributes[0].Value;
            source = node.Attributes[1].Value;
            message = node.Attributes[2].Value;

            

            string[] dateTime = readDate.Split(' ');
            string []day = dateTime[0].Split('-');
            string[] time = dateTime[1].Split(':');

            info[0] = dateTime[0];
            info[1] = dateTime[1];
            info[2] = source;
            info[3] = message;

            date = new DateTime(Int16.Parse(day[0]), Int16.Parse(day[1]), Int16.Parse(day[2]), Int16.Parse(time[0]), Int16.Parse(time[1]), Int16.Parse(time[2]));

        }

        public string[] getLog(){
            return info;
        }
    }
}
