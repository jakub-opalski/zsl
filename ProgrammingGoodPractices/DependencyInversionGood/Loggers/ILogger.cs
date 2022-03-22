using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversionGood.Loggers
{
    public interface ILogger
    {
        void LogMessage(string message);
    }
}
