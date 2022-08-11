namespace Common.Interfaces
{
    public interface ICustomLogger
    {
        void LogToConsole(string message);
        void LogToFile(string message);
    }
}
