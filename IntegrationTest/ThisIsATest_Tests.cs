using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTest;

namespace IntegrationTest
{
    [TestClass]
    public class ThisIsATest_Tests
    {
        ILogger logger;

        public ThisIsATest_Tests()
        {
            logger = new ConsoleLogger();
        }
        [TestMethod]
        public void SortParagraph_WordSort()
        {        
            Assert.AreEqual("Boom Zoom", SimpleTest.MyTest.SortParagraph("Zoom Boom", logger));
        }

        [TestMethod]
        public void SortParagraph_CaseSort()
        {        
            Assert.AreEqual("Boom boom", SimpleTest.MyTest.SortParagraph("boom Boom", logger));
        }

         [TestMethod]
        public void SortParagraph_RemoveInvalidChars()
        {        
            Assert.AreEqual("b b", SimpleTest.MyTest.SortParagraph("b, b", logger));
        }

        [TestMethod]
        public void SortParagraph_SimpleTest1()
        {        
            Assert.AreEqual("baby Go go", SimpleTest.MyTest.SortParagraph("Go baby, go", logger));
        }

        [TestMethod]
        public void SortParagraph_SimpleTest2()
        {
            Assert.AreEqual("ABC aBc abc CBA CBA cba", SimpleTest.MyTest.SortParagraph("CBA, abc aBc ABC cba CBA.", logger));
        }

        [TestMethod]
        public void SortParagraph_doubleSpace()
        {
            Assert.AreEqual("ABC aBc abc CBA CBA cba", SimpleTest.MyTest.SortParagraph("CBA, abc  aBc ABC cba CBA.", logger));
        }
    }
}