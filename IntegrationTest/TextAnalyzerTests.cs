using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleTest.Tests
{
    [TestClass]
    public class TextAnalyzerTests
    {
        private TextAnalyzer _textAnalyzer = null!;

        [TestInitialize]
        public void Setup()
        {
            //Arrange
            _textAnalyzer = new TextAnalyzer(new ConsoleLogger());
        }

        [TestMethod]
        public void ParseText_Can_WordSort()
        {
            //Act
            var result = _textAnalyzer.ParseText("Zoom Boom");

            //Assert
            Assert.AreEqual("Boom Zoom", result);
        }

        [TestMethod]
        public void ParseText_Can_CaseSort()
        {        
            //Act
            var result = _textAnalyzer.ParseText("boom Boom");

            //Assert
            Assert.AreEqual("Boom boom", result);
        }

         [TestMethod]
        public void ParseText_Can_RemoveInvalidChars()
        {        
            //Act
            var result = _textAnalyzer.ParseText("b, b");

            //Assert
            Assert.AreEqual("b b", result);
        }

        [TestMethod]
        public void ParseText_Can_Handle_Comma_Seperated_Text()
        {        
            //Act
            var result = _textAnalyzer.ParseText("Go baby, go");

            //Assert
            Assert.AreEqual("baby Go go", result);
        }

        [TestMethod]
        public void ParseText_Can_Handle_Sorting_MultiCase_Text_With_Dot()
        {
            //Act
            var result = _textAnalyzer.ParseText("CBA, abc aBc ABC cba CBA.");

            //Assert
            Assert.AreEqual("ABC aBc abc CBA CBA cba", result);
        }
    }
}