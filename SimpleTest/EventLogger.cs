namespace SimpleTest;

public class EventLogger : ILogger
{
    //Different loggers can be instantiated using IoC and strategy pattern. 
    public void Log(string stuff)
    {
        throw new NotImplementedException();
    }
}