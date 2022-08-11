using AutoFixture.Xunit2;
using Common.Interfaces;
using Core.Interfaces;
using Core.SortingLogic;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Xunit;

namespace Core.UnitTests.SortingLogic
{
    public class SortingLogicTests
    {
        private readonly TextABCSort _objectToTest;
        private readonly Mock<ICustomLogger> _mockLogger;
        private readonly Mock<IStringSorter> _mockStringSorter;

        public SortingLogicTests()
        {
            _mockLogger = new Mock<ICustomLogger>();
            _mockStringSorter = new Mock<IStringSorter>();

            _objectToTest = new TextABCSort();
        }

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
    }
}
