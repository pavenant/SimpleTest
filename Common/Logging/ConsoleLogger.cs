using Common.Interfaces;

namespace Common.Logging {
    
    /// <summary>
    /// Implementation for console based logger
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Log data to the console
        /// </summary>
        /// <param name="data">Data to be logged</param>
        public void Log(string data)
        {
            Console.WriteLine(data);
        }
    }
}