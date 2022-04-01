using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//simple test

//Test 


namespace SimpleTest
{
    public static partial class MyTest
    {
        public static string CalculateTotal(string someInput)
        {
            var logger = new ConsoleLogger(); // new EventLogger();
            
            if (string.IsNullOrEmpty(someInput))
            {
                throw new Exception("data not correct");
            }

            Log(logger, "start CalculateTotal");

            //algorithm
            string cleanInput = CleanupChars(someInput);

            var orderedEnum = cleanInput
                                .Split(' ')
                                .Select(s => s)
                                .OrderBy(s => s, StringComparer.OrdinalIgnoreCase)
                                .ThenBy(s => s, StringComparer.Ordinal);

            string result = String.Join(" ", orderedEnum);

            Log(logger, "end CalculateTotal");

            return result;
        }

        // private for same accessibility as ILogger
        private static string CalculateTotalInjectedLogger(string someInput, ILogger logger)
        {            
            if (string.IsNullOrEmpty(someInput))
            {
                throw new Exception("data not correct");
            }

            logger.Log("end CalculateTotal");

            //algorithm
            string cleanInput = CleanupChars(someInput);

            var orderedEnum = cleanInput
                                .Split(' ')
                                .Select(s => s)
                                .OrderBy(s => s, StringComparer.OrdinalIgnoreCase)
                                .ThenBy(s => s, StringComparer.Ordinal);

            string result = String.Join(" ", orderedEnum);

            logger.Log("end CalculateTotal");
            return result;
        }

        private static string CleanupChars(string s)
        {
            return s.Replace(".", "").Replace(",", "").Replace(";", "").Replace("'", "");
        }

        internal class ConsoleLogger : ILogger
        {
            public void Log(string stuff)
            {
                Console.WriteLine(stuff);
            }
        }

        internal class EventLogger : ILogger {
            public void Log(string stuff)
            {
                // TODO EventLog Accordingly
                throw new NotImplementedException();
            }
        }

        // Method Overloads version
        private static void Log(ConsoleLogger logger, string message)
        {
            logger.Log(message);
        }
        private static void Log(EventLogger logger, string message)
        {
            logger.Log(message);
        }
    }
}
