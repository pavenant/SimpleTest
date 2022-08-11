using Common;
using Common.Interfaces;
using Common.Logging;
using Core.Interfaces;

namespace Core.SortingLogic
{
    /// <summary>
    /// TextABCSort
    /// </summary>
    public class TextABCSort : IStringSorter
    {
        private readonly ICustomLogger _logger;

        public TextABCSort()
        {
            _logger = new CustomLogger();
        }

        public TextABCSort(ICustomLogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Sorting Implementation to be used to aid reading though the words 
        /// alphabetically and easily see all the variants of different case
        /// 
        /// words should be reordered Alphabetically - (Zerbra Abba) becomes (Abba Zebra)
        /// words should THEN be ordered from upper case to lower case. 
        /// Note point 1 takes preference. (aBba Abba) becomes (Abba aBba)
        /// remove all (.,;') chars. (aBba, Abba) becomes (Abba aBba)
        /// </summary>
        /// <param name="stringInput"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string Sort(string stringInput)
        {
            if (stringInput == null)
            {
                throw new ArgumentNullException(nameof(stringInput), "String input is required");
            }
            
            _logger.LogToConsole("start ABC Sort");

            // sorting algorithm
            // remove all(.,; ') chars. (aBba, Abba) becomes (Abba aBba)
            foreach (var item in Constants.CLEANUP_CHARACTERS)
            {
                stringInput = stringInput.Replace(item, string.Empty);
            }

            // split out the words
            var words = stringInput.Split(' ').ToList();
            // words should be reordered Alphabetically - (Zerbra Abba) becomes (Abba Zebra)
            words.Sort((x, y) => string.Compare(x, y));

            // words should THEN be ordered from upper case to lower case.
            var sortedWords = 
                words.OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
                .ThenBy(x => x, StringComparer.Ordinal);

            // Do not remove duplicate words
            
            _logger.LogToConsole("end ABC Sort");
            return string.Join(" ", sortedWords);            
        }
    }
}
