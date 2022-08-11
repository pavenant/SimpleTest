using Common.Logging;
using Core.SortingLogic;
using TextSort;

internal class Program
{
    /// <summary>
    /// Test program for running the sort
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // Ideally we would inject this using the interface
        var logger = new ConsoleLogger();
        Console.WriteLine("Hello World!");

        var textSort = new TextSort.TextSort(new TextSortSettings
        {            
            StringSorter = new TextABCSort(logger)
        });


    }
}
