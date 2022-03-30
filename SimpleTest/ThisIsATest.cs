using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//simple test

//Test 


namespace SimpleTest
{
    public static partial class MyTest
    {
        public static string CalculateTotal(string someInput)
        {
            var log = new ConsoleLogger();

            if (string.IsNullOrWhiteSpace(someInput))
            {
                throw new ArgumentNullException("data not correct");
            }
            
            log.Log("start CalculateTotal");

            //algorithm
            var pattern = new Regex("[.,;']");
            var filteredWords = pattern.Replace(someInput, "");

            var words = filteredWords.Split(' ');

            var orderedWords = words.OrderBy(x => x);

            var upperToLowerCaseSort = orderedWords
                .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
                .ThenBy(x => x, StringComparer.Ordinal);

            var orderedWordString = string.Join(" ", upperToLowerCaseSort);

            log.Log("end CalculateTotal");

            return orderedWordString;
        }

        internal class ConsoleLogger : ILogger
        {
            public void Log(string stuff)
            {
                Console.WriteLine(stuff);
            }
        }

    }
}
