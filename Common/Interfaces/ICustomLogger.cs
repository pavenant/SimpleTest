namespace Common.Interfaces
{
    /// <summary>
    /// Custom logger interface
    /// </summary>
    public interface ICustomLogger
    {
        /// <summary>
        /// Interface member to log to console
        /// </summary>
        /// <param name="message">Message to log</param>
        void LogToConsole(string message);

        /// <summary>
        /// Interface member to log to file
        /// </summary>
        /// <param name="message">Message to log</param>
        void LogToFile(string message);
    }
}
