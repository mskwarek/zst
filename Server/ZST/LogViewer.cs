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
    /// <summary>
    /// Klasa reprezentująca wyświetlanie logów
    /// </summary>
    class LogViewer
    {
        /// <summary>
        /// miejsce wyświetlania logów (użyty framework ObjectListView)
        /// </summary>
        private ObjectListView objlv;

        /// <summary>
        /// Konstruktor klasy wyświetlania logów
        /// </summary>
        /// <param name="objlv">miejsce w Form gdzie logi mają być wyswietlane</param>
        public LogViewer(ObjectListView objlv)
        {
            this.objlv = objlv;
        }

        /// <summary>
        /// Odświeżanie listy logów
        /// </summary>
        /// <param name="log">Otrzymany, nowy log</param>
        /// <param name="list">Lista którą nalezy odświeżyć</param>
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
