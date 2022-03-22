using DependencyInversionGood.Loggers;
using System;

namespace DependencyInversionGood.Helpers
{
    public class ExceptionLogger
    {
        private ILogger _logger;
        public ExceptionLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void LogException(Exception ex)
        {
            _logger.LogMessage(GetUserReadableMessage(ex));
        }

        public string GetUserReadableMessage(Exception ex)
        {
            return ex.Message;
        }
    }
}
