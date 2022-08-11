namespace Common.Interfaces
{
    /// <summary>
    /// Simple log interface to promote loose coupling 
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Simple member to log string data
        /// </summary>
        /// <param name="data">Data to be logged</param>
        void LogMessage(string data);

        /// <summary>
        /// Member to log exceptions
        /// </summary>
        /// <param name="exception"></param>
        void LogException(Exception exception);
    }
}
