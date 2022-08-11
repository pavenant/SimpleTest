using Common.Interfaces;

namespace Common.Logging
{
    /// <summary>
    /// Intermediate logging class
    /// Adapter pattern to allow logger implementation to be swapped
    /// </summary>
    public class Logger : ILogger
    {
        private readonly ICustomLogger _customLogger;

        public Logger(ICustomLogger customLogger)
        {
            _customLogger = customLogger;
        }

        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="exception">Exception to log</param>
        public void LogException(Exception exception)
        {
            // we could apply custom formatting, or redaction to how we want the exception to be logged
            _customLogger.LogToConsole(exception.Message);
        }

        /// <summary>
        /// Log message/data
        /// </summary>
        /// <param name="data">Message/data to log</param>
        public void LogMessage(string data)
        {
            // we could apply custom formatting, or redaction to how we want the data to be logged
            _customLogger.LogToConsole(data);
        }
    }
}
