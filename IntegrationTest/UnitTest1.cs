

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {
        private const string ExceptionMessage = "data not correct";

        [TestMethod]
        public void CalculateTotal_SortsByWord()
        {        
            Assert.AreEqual("Boom Zoom", SimpleTest.MyTest.CalculateTotal("Zoom Boom"));
        }

        [TestMethod]
        public void CalculateTotal_SortsByCase()
        {        
            Assert.AreEqual("Boom boom", SimpleTest.MyTest.CalculateTotal("boom Boom"));
        }

        [TestMethod]
        public void CalculateTotal_RemovesInvalidCharacters()
        {        
            Assert.AreEqual("b b", SimpleTest.MyTest.CalculateTotal("b.,;' b"));
        }

        [TestMethod]
        public void CalculateTotal_ByWordCaseAndRemovesInvalidCharacters_SimpleTest1()
        {        
            Assert.AreEqual("baby Go go", SimpleTest.MyTest.CalculateTotal("Go baby, go"));
        }

        [TestMethod]
        public void CalculateTotal_ByWordCaseAndRemovesInvalidCharacters_SimpleTest2()
        {
            Assert.AreEqual("ABC aBc abc CBA CBA cba", SimpleTest.MyTest.CalculateTotal("CBA, abc aBc ABC cba CBA."));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), ExceptionMessage)]
        public void CalculateTotal_WhenInputIsNull_ThenRaiseNullException()
        {
            SimpleTest.MyTest.CalculateTotal(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), ExceptionMessage)]
        public void CalculateTotal_WhenInputIsEmpty_ThenRaiseNullException()
        {
            SimpleTest.MyTest.CalculateTotal("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), ExceptionMessage)]
        public void CalculateTotal_WhenInputIsSpace_ThenRaiseNullException()
        {
            SimpleTest.MyTest.CalculateTotal(" ");
        }

    }
}