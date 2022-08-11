using Common.Interfaces;

namespace Common.Logging
{
    /// <summary>
    /// Implementation for custom logging logic
    /// Could swap this out for SEQ, Log4Net or Similar
    /// </summary>
    public class CustomLogger : ICustomLogger
    {
        /// <summary>
        /// Log the message to the console
        /// </summary>
        /// <param name="message">Message to log</param>
        public void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Log the message to a file
        /// </summary>
        /// <param name="message">File to log</param>
        /// <exception cref="NotImplementedException"></exception>
        public void LogToFile(string message)
        {
            throw new NotImplementedException();
        }
    }
}
