using System;
using TestNinja.Fundamentals;
using Xunit;

namespace UnitTestExercisesTests.Fundamentals
{
    public class ErrorLoggerTests
    {
        [Fact]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            //Arrange
            var logger = new ErrorLogger();

            //Act
            logger.Log("a");

            //Assert
            Assert.Equal("a", logger.LastError);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            //Arrange
            var logger = new ErrorLogger();

            //Assert
            Assert.Throws<ArgumentNullException>(() => logger.Log(error));
        }

        [Fact]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };

            //Act
            logger.Log("a");

            //Assert
            Assert.NotEqual(Guid.Empty, id);
        }
    }
}
