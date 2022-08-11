using Common.Enums;
using Common.Interfaces;
using Common.Logging;
using Common.Models;
using Core.Interfaces;
using Core.SortingFactory;
using Core.SortingLogic;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    /// <summary>
    /// Test program for running the sort
    /// </summary>
    /// <param name="args"></param>

    static void Main(string[] args)
    {
        // setup our DI, ideally this would be elsewhere
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ISortingFactory, SortingFactory>()
            .AddSingleton<ILogger, Logger>()
            .AddSingleton<ICustomLogger, CustomLogger>()
            .AddSingleton<IStringSorter, TextABCSort>()
            .BuildServiceProvider();

        var logger = serviceProvider.GetService<ILogger>();

        try
        {
            Console.WriteLine("Please chose the sort type to run ");
            Console.WriteLine("1. Text Sort -> ABC Sort");
            Console.WriteLine("2. Numeric Sort -> ASC Sort");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input)) { 
                SortingType sortingType = default;
                SortingSubType sortingSubType = default;
                int.TryParse(input, out int value);

                switch (value)
                {
                    case 1:
                        sortingType = SortingType.StringSort;
                        sortingSubType = SortingSubType.TextABCSort;
                        break;
                }

                if (value > 1)
                {
                    Console.WriteLine("Not yet implemented");
                }
                else
                {
                    if (value > 0)
                    {
                        Console.WriteLine("Please enter your input to sort");
                        var textToSort = new StringInput { Input = Console.ReadLine() };
                        Console.WriteLine();

                        // this is a little messy, but demonstrates use of factory pattern
                        var sortingFactory = serviceProvider.GetService<ISortingFactory>();
                        ISortingLogic<StringInput, StringOutput>? sortingLogic
                            = sortingFactory.CreateSortingLogic<StringInput, StringOutput>(sortingType, sortingSubType);

                        var output = sortingLogic.Sort(textToSort);
                        Console.WriteLine();
                        Console.WriteLine("Here is your sorted string");
                        Console.WriteLine(output);
                    }
                    else
                    {
                        Console.WriteLine("You did not select a sort.");
                    }
                }
            }
        } 
        // example of handling certain exception types differently
        catch (ArgumentNullException ex)
        {
            logger.LogMessage(ex.Message);
        }
        // catch all for any other errors
        catch (Exception ex)
        {
            logger.LogException(ex);
        } 
        // cleanup, or other operation that should always happen
        finally
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
            Console.WriteLine("Goodbye.");
        }
    }
}
