

using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SimpleTest;
using System;

namespace IntegrationTest
{
    [TestFixture]
    public class UnitTest1
    {
        private ThisIsATest _sut;

        private Mock<ILogger<ThisIsATest>> _loggerMock;

        private const string ExceptionMessage = "data not correct (Parameter 'someInput')";
        private const string ParameterName = "someInput";

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger<ThisIsATest>>();

            _sut = new ThisIsATest(_loggerMock.Object);
        }

        [Test]
        public void CalculateTotal_SortsByWord()
        {        
            Assert.AreEqual("Boom Zoom", _sut.CalculateTotal("Zoom Boom"));
        }

        [Test]
        public void CalculateTotal_SortsByCase()
        {        
            Assert.AreEqual("Boom boom", _sut.CalculateTotal("boom Boom"));
        }

        [Test]
        public void CalculateTotal_RemovesInvalidCharacters()
        {        
            Assert.AreEqual("b b", _sut.CalculateTotal("b.,;' b"));
        }

        [Test]
        public void CalculateTotal_ByWordCaseAndRemovesInvalidCharacters_SimpleTest1()
        {        
            Assert.AreEqual("baby Go go", _sut.CalculateTotal("Go baby, go"));
        }

        [Test]
        public void CalculateTotal_ByWordCaseAndRemovesInvalidCharacters_SimpleTest2()
        {
            Assert.AreEqual("ABC aBc abc CBA CBA cba", _sut.CalculateTotal("CBA, abc aBc ABC cba CBA."));
        }

        [Test]
        public void CalculateTotal_WhenInputIsNull_ThenRaiseNullException()
        {
            var result = Assert.Throws<ArgumentNullException>(() => _sut.CalculateTotal(null));

            Assert.AreEqual(result.ParamName, ParameterName);
            Assert.AreEqual(result.Message, ExceptionMessage);
        }

        [Test]
        public void CalculateTotal_WhenInputIsEmpty_ThenRaiseNullException()
        {
            var result = Assert.Throws<ArgumentNullException>(() => _sut.CalculateTotal(""));

            Assert.AreEqual(result.ParamName, ParameterName);
            Assert.AreEqual(result.Message, ExceptionMessage);
        }

        [Test]
        public void CalculateTotal_WhenInputIsSpace_ThenRaiseNullException()
        {
            var result = Assert.Throws<ArgumentNullException>(() => _sut.CalculateTotal(" "));

            Assert.AreEqual(result.ParamName, ParameterName);
            Assert.AreEqual(result.Message, ExceptionMessage);
        }

        [Test]
        public void CalculateTotal_LogsStart()
        {
            _sut.CalculateTotal("A");

            _loggerMock.VerifyInfoWasCalled("start CalculateTotal");
        }

        [Test]
        public void CalculateTotal_LogsEndt()
        {
            _sut.CalculateTotal("A");

            _loggerMock.VerifyInfoWasCalled("end CalculateTotal");
        }
    }
}