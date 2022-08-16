namespace SimpleTest;

internal class ConsoleLogger : ILogger
{
    public void Log(string stuff)
    {
        Console.WriteLine(stuff);
    }
}