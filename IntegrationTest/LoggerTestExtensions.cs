using Microsoft.Extensions.Logging;
using Moq;
using System;

namespace IntegrationTest
{
    public static class LoggerTestExtensions
    {
        public static Mock<ILogger<T>> VerifyInfoWasCalled<T>(this Mock<ILogger<T>> logger, string message)
        {
            return logger.VerifyLogLevel(LogLevel.Information, message, Times.Once());
        }

        static Mock<ILogger<T>> VerifyLogLevel<T>(this Mock<ILogger<T>> logger, LogLevel logLevel, string message, Times times)
        {
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == logLevel),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => message == null || v.ToString().Contains(message)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                times);

            return logger;
        }
    }
}
