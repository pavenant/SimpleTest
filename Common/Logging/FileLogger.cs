using Common.Interfaces;

namespace Common.Logging
{
    /// <summary>
    /// Implementation for file based logger
    /// </summary>
    public class FileLogger : ILogger
    {
        /// <summary>
        /// Log data to file
        /// </summary>
        /// <param name="data">Data to be logged</param>
        public void Log(string data)
        {
            throw new NotImplementedException();
        }
    }
}
