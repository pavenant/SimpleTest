

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WordSort()
        {        
            Assert.AreEqual("Boom Zoom", TextABCSort.MyTest.CalculateTotal("Zoom Boom"));
        }

        [TestMethod]
        public void CaseSort()
        {        
            Assert.AreEqual("Boom boom", TextABCSort.MyTest.CalculateTotal("boom Boom"));
        }

         [TestMethod]
        public void RemoveInvalidChars()
        {        
            Assert.AreEqual("b b", TextABCSort.MyTest.CalculateTotal("b, b"));
        }

        [TestMethod]
        public void SimpleTest1()
        {        
            Assert.AreEqual("baby Go go", TextABCSort.MyTest.CalculateTotal("Go baby, go"));
        }

        [TestMethod]
        public void SimpleTest2()
        {
            Assert.AreEqual("ABC aBc abc CBA CBA cba", TextABCSort.MyTest.CalculateTotal("CBA, abc aBc ABC cba CBA."));
        }
    }
}