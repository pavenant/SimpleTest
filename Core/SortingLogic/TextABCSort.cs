using Common.Interfaces;
using Core.Interfaces;

namespace Core.SortingLogic
{
    /// <summary>
    /// TextABCSort
    /// </summary>
    public class TextABCSort : IStringSorter
    {
        private readonly ILogger _logger;
        public TextABCSort(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Sorting Implementation to be used to aid reading though the words 
        /// alphabetically and easily see all the variants of different case
        /// </summary>
        /// <param name="stringInput"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string SortString(string stringInput)
        {
            if (stringInput == null)
            {
                throw new ArgumentNullException(nameof(stringInput), "String input is required");
            }
            
            _logger.Log("start ABC Sort");

            //TODO: sorting algorithm
            // words should be reordered Alphabetically - (Zerbra Abba) becomes (Abba Zebra)
            // words should THEN be ordered from upper case to lower case. Note point 1 takes preference. (aBba Abba) becomes (Abba aBba)
            // remove all (.,;') chars. (aBba, Abba) becomes (Abba aBba)
            // Do not remove duplicate words

            _logger.Log("end ABC Sort");
            return stringInput;            
        }
    }
}
