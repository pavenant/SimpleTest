using System.Text.RegularExpressions;

namespace SimpleTest
{
    public static class MyTest
    {
        public static string SortParagraph(string someInput,ILogger logger)
        {
            //clean and prep list input before validate
            someInput = Regex.Replace(someInput, "[,.;]", " "); //catering for paragraphs containing "abd,adv abd)
            var stringList = someInput.Split(' ').ToList();
            stringList = stringList.Where(s => !string.IsNullOrEmpty(s)).ToList(); //removing blank list items due to double spaces

            //validate
            var log = new ConsoleLogger();
            if (String.IsNullOrEmpty(someInput))
            {
                throw new DataMisalignedException("Not Data to sort");
            }
            
            log.Log("Start SortParagraph");

            //algorithm
            var sortedList = stringList.OrderBy(s => s, StringComparer.OrdinalIgnoreCase).ThenBy(s => s, StringComparer.Ordinal);

            log.Log("End SortParagraph");
            return String.Join(" ", sortedList);
        }
    }
}
