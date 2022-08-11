using AutoFixture.Xunit2;
using Common.Interfaces;
using Common.Logging;
using Moq;
using Xunit;

namespace Common.UnitTests.Logging
{
    public class LoggerTests
    {
        private ILogger _objectToTest;

        private readonly Mock<ICustomLogger> _mockCustomLogger;

        public LoggerTests()
        {
            _mockCustomLogger = new Mock<ICustomLogger>();
        }

        public class Log : LoggerTests
        {
            // TODO: Add logger tests
        }
    }
}
