using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionGood.Loggers
{
    public class DbLogger : ILogger
    {
        public void LogMessage(string message)
        {
            //log message in database
        }
    }
}
