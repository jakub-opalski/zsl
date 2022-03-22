namespace DependencyInversionGood.Loggers
{
    public class EventLogger : ILogger
    {
        public void LogMessage(string message)
        {
            //log to event viewer
        }
    }
}
