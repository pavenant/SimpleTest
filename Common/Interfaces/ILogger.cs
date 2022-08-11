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
        void Log(string data);
    }
}
