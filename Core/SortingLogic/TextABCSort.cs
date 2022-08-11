using Common;
using Common.Interfaces;
using Common.Logging;
using Common.Models;
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
        /// <param name="stringInput">The string to sort</param>
        /// <returns>The sorted string</returns>
        /// <exception cref="ArgumentNullException">String input is required</exception>
        public string Sort(string stringInput)
        {
            // ensure input is valid, exception handling should be done by calling code
            if (stringInput == null || string.IsNullOrWhiteSpace(stringInput) || stringInput.Length <= 0)
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

            // split out the words into a list so that we can sort
            var words = stringInput.Split(' ').ToList();

            // words should be reordered Alphabetically - (Zerbra Abba) becomes (Abba Zebra)
            words.Sort((x, y) => string.Compare(x, y));

            // words should THEN be ordered from upper case to lower case.
            var sortedWords =
                // use the OrdinalIgnoreCase comparer, which will group the characters up.
                words.OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
                // sort those groups ordinally to get the capitals to come first
                .ThenBy(x => x, StringComparer.Ordinal);

            // Do not remove duplicate words
            // nothing to do here

            _logger.LogToConsole("end ABC Sort");

            // join list back to a paragraph
            return string.Join(" ", sortedWords);            
        }

        public StringOutput Sort(StringInput someInput)
        {
            return new StringOutput { Output = this.Sort(someInput.Input) };
        }
    }
}
