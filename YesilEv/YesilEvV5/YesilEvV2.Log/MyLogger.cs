using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvV2.Log
{
    public class MyLogger : ILogger
    {
        public static MyLogger Instance;
        public static Logger logger;


        // single design pattern ile - private constructor      (singleton dp)
        private MyLogger()
        {

        }
        public static MyLogger GetInstance()
        {
            if (Instance==null)
            {
                Instance = new MyLogger();
            }
            return Instance;
        }


        private Logger GetLogger(string theLogger)
        {
            if (MyLogger.logger==null)
            {
                MyLogger.logger = LogManager.GetLogger(theLogger);
            }
            return MyLogger.logger;
        }

        public void Debug(string message, string arg = null)
        {
            if (arg==null)
            {
                GetLogger("myAppLoggerRules").Debug(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Debug(message,arg);
            }
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRules").Error(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Error(message, arg);
            }
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRules").Info(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Info(message, arg);
            }
        }

        public void Trace(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRules").Trace(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Trace(message, arg);
            }
        }
    }
}
