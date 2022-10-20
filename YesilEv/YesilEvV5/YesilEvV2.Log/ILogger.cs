using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvV2.Log
{
    public interface ILogger
    {
        void Info(string message, string arg=null);
        void Debug(string message, string arg=null);
        void Error(string message, string arg=null);
        void Trace(string message, string arg=null);
    }
}
