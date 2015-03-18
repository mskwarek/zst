using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZST
{
    class LogArgs : EventArgs
    {
        private string[] message;

        public LogArgs(string[] message)
        {
            this.message = message;
        }

        // This is a straightforward implementation for 
        // declaring a public field
        public string[] Message
        {
            get
            {
                return message;
            }
        }
    }
}
