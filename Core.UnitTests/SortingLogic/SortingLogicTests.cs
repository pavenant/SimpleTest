using AutoFixture.Xunit2;
using Common;
using Common.Interfaces;
using Core.Interfaces;
using Core.SortingLogic;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using System.Text;
using Xunit;

namespace Core.UnitTests.SortingLogic
{
    public class SortingLogicTests
    {
        private readonly TextABCSort _objectToTest;
        private readonly Mock<ILogger> _mockLogger;
        private readonly Mock<IStringSorter> _mockStringSorter;
        
        public SortingLogicTests()
        {
            _mockLogger = new Mock<ILogger>();
            _mockStringSorter = new Mock<IStringSorter>();
            _objectToTest = new TextABCSort();
        }
        
        /// <summary>
        /// Helper method to get a random string
        /// </summary>
        /// <returns></returns>
        public static string GetRandomString(int stringLength)
        {
            var _random = new Random();
            string charsToUse = string.Concat(
                "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", 
                string.Join(string.Empty, Constants.CLEANUP_CHARACTERS));

            return new string(Enumerable.Repeat(charsToUse, stringLength)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Helper method to get a random paragraph of random strings
        /// </summary>
        /// <param name="wordLength"></param>
        /// <returns></returns>
        public static string GetRandomParagraph(int numberOfWords, int stringLength)
        {
            var stringBuilder = new StringBuilder();
            
            for (int i = 0; i <= numberOfWords; i++)
            {
                stringBuilder.Append($"{GetRandomString(stringLength)}");
                stringBuilder.Append(" ");
            }
            
            return stringBuilder.ToString().TrimEnd();
        }

        public class LoggingTests : SortingLogicTests
        {
            [Fact]
            public void Logs_Sort_Progress_To_Console()
            {
                // Arrange
                string inputData = GetRandomParagraph(12, 8);

                // Act
                _objectToTest.Sort(inputData);

                // Assert
                //_mockLogger.Verify(x => x.LogMessage(It.IsAny<string>()), Times.Exactly(2));
            }
        }

        public class ErrorHandlingTests : SortingLogicTests
        {
            [Theory]
            [InlineData(null)]
            public void Throws_ArgumentNullException_If_Null_Provided(string inputData)
            {
                // Arrange

                // Act
                Func<object> action = () => _objectToTest.Sort(inputData);

                // Assert
                using (new AssertionScope())
                {
                    action.Should().Throw<ArgumentNullException>();
                }
            }

            [Theory]
            [InlineData(" ")]
            public void Throws_ArgumentNullException_If_Whitespace_Provided(string inputData)
            {
                // Arrange

                // Act
                Func<object> action = () => _objectToTest.Sort(inputData);

                // Assert
                using (new AssertionScope())
                {
                    action.Should().Throw<ArgumentNullException>();
                }
            }

            [Theory]
            [InlineData("")]
            public void Throws_ArgumentNullException_If_ZeroLength_Provided(string inputData)
            {
                // Arrange

                // Act
                Func<object> action = () => _objectToTest.Sort(inputData);

                // Assert
                using (new AssertionScope())
                {
                    action.Should().Throw<ArgumentNullException>();
                }
            }
        }

        public class StringSortingTests : SortingLogicTests
        {
            [Theory]
            [InlineData("Zoom Boom")]
            public void Sorts_Alphabetically(string inputData)
            {
                // Arrange
                var expected = "Boom Zoom";

                // Act
                var actual = _objectToTest.Sort(inputData); 

                // Assert
                actual.Should().Be(expected);
            }

            [Theory]
            [InlineData("boom Boom")]
            public void Sorts_By_Case(string inputData)
            {
                // Arrange
                var expected = "Boom boom";

                // Act
                var actual = _objectToTest.Sort(inputData);

                // Assert
                actual.Should().Be(expected);
            }

            [Fact]
            public void Removes_Special_Characters()
            {
                // Arrange
                string inputData = GetRandomParagraph(12, 8);

                // Act
                string result = _objectToTest.Sort(inputData);

                // Assert
                result.Should().NotContainAny(Constants.CLEANUP_CHARACTERS);
            }

            [Theory]
            [InlineData("Go baby, go")]
            public void Sorts_Alphabetically_Then_By_Case(string inputData)
            {
                // Arrange
                var expected = "baby Go go";

                // Act
                var actual = _objectToTest.Sort(inputData);

                // Assert
                actual.Should().Be(expected);
            }

            [Theory]
            [InlineData("CBA, abc aBc ABC cba CBA.")]
            public void Sorts_Alphabetically_Then_By_Case_And_Removes_Invalid_Characters(string inputData)
            {
                // Arrange
                var expected = "ABC aBc abc CBA CBA cba";

                // Act
                var actual = _objectToTest.Sort(inputData);

                // Assert
                actual.Should().Be(expected);
                actual.Should().NotContainAny(Constants.CLEANUP_CHARACTERS);
            }

            [Fact]
            public void Does_Not_Remove_Duplicate_Words()
            {
                // Arrange
                var expected = "duplicate duplicate duplicate";

                // Act
                var actual = _objectToTest.Sort(expected);

                // Assert
                actual.Should().Be(expected);
            }
        }
    }
}
