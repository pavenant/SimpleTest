using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

//simple test

//Test 


namespace SimpleTest
{
    public class ThisIsATest
    {
        private readonly ILogger<ThisIsATest> _logger;

        public ThisIsATest(ILogger<ThisIsATest> logger) 
        { 
            _logger = logger; 
        }

        public string CalculateTotal(string someInput)
        {
            if (string.IsNullOrWhiteSpace(someInput))
            {
                throw new ArgumentNullException(nameof(someInput), "data not correct");
            }
  
            _logger.LogInformation("start CalculateTotal");

            //algorithm
            var pattern = new Regex("[.,;']");
            var filteredWords = pattern.Replace(someInput, "");

            var words = filteredWords.Split(' ');

            var orderedWords = words.OrderBy(x => x);

            var upperToLowerCaseSort = orderedWords
                .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
                .ThenBy(x => x, StringComparer.Ordinal);

            var orderedWordString = string.Join(" ", upperToLowerCaseSort);

            _logger.LogInformation("end CalculateTotal");

            return orderedWordString;
        }


    }
}
