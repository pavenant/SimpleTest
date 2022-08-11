namespace TextSort
{
    public class TextSort
    {        
        public TextSort(TextSortSettings sortSettings)
        {
            var stringSorter = sortSettings.StringSorter.Sort("hello");
        }                
    }
}
