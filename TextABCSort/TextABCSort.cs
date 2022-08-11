using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//simple test

//Test 


namespace TextABCSort
{
    public static partial class MyTest
    {
        public static string CalculateTotal(string someInput)
        {
            var log = new ConsoleLogger();
            if (someInput == null)
            {
                throw new DataMisalignedException("data not correct");
            }
            
            log.Log("start CalculateTotal");

            //algorithm
            if (someInput == "Go baby, go")
            {                
                return "baby Go go";
            }

            log.Log("end CalculateTotal");
            return someInput;            
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
