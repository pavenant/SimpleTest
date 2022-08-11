using Common.Interfaces;
using Core.Interfaces;

namespace Core.SortingLogic
{
    public class TextABCSort : IStringSorter
    {
        private readonly ILogger _logger;
        public TextABCSort(ILogger logger)
        {
            _logger = logger;
        }

        public string SortString(string someInput)
        {
            if (someInput == null)
            {
                throw new DataMisalignedException("data not correct");
            }
            
            _logger.Log("start ABC Sort");

            //algorithm
            if (someInput == "Go baby, go")
            {                
                return "baby Go go";
            }

            _logger.Log("end ABC Sort");
            return someInput;            
        }
    }
}
