using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            BaseLoggerMixins.Error(null, "");
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_WithNullLogger_ThrowsException()
        {
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            BaseLoggerMixins.Warning(null, "");
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            BaseLoggerMixins.Information(null, "");
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            BaseLoggerMixins.Debug(null, "");
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();
            
            // Act
            logger.Error("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Warning_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();
            
            // Act
            logger.Warning("Message {0}", 34);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 34", logger.LoggedMessages[0].Message);
        }
        
        [TestMethod]
        public void Information_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();
            
            // Act
            logger.Information("Message {0}", "test");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message test", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Debug_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();
            
            // Act
            logger.Debug("Message {0}", 99);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 99", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Error_paramArr_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();
            
            // Act
            logger.Error("Message {0}, {1}, {2}, {3}", 99, 44, "steve", 5.421);

            // Assert
            Assert.AreEqual("Message 99, 44, steve, 5.421", logger.LoggedMessages[0].Message);
        }


    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}
