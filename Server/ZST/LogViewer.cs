using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ZST
{
    class LogViewer
    {

        private ObjectListView objlv;

        public LogViewer(ObjectListView objlv)
        {
            this.objlv = objlv;
        }

        public void updateLogList(Log log, List<Log> list)
        {
                objlv.Invoke(new MethodInvoker(delegate()
                        {
                            list.Add(log);
                            var listViewItem = new ListViewItem(log.getLog());
                            this.objlv.AddObject(log);
                        })
                    );  
        }
    }
}
