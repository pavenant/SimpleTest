namespace SimpleTest
{
    /// <summary>
    /// Text Analyzer library that parses and returns words alphabetically in an easy to read format.
    /// </summary>
    public class TextAnalyzer
    {
        private readonly ILogger _logger;

        //Different loggers can be injected in as required.
        public TextAnalyzer(ILogger logger)
        {
            _logger = logger;
        }

        public string ParseText(string inputParagraph)
        {
            if (inputParagraph == null)
            {
                throw new InvalidDataException("Data cannot be null");
            }

            _logger.Log("Start ParseText");

            inputParagraph = ReorderAlphabetically(inputParagraph);

            _logger.Log("End ParseText");
            return inputParagraph;            
        }

        private string ReorderAlphabetically(string input)
        {
            var arrayStrings = input.Split(' ');
            Array.Sort(arrayStrings, new StringCompare());

            var charsToRemove = new char[] { '.', ',', ';', '\'' };
            var invalidCharsRemoved = string.Join(' ', arrayStrings).Split(charsToRemove);

            return string.Join("", invalidCharsRemoved);
        }

    }
}
