using System;
using TestNinja.Fundamentals;
using Xunit;

namespace UnitTestExercisesTests.Fundamentals
{
    public class DemeritPointsCalculatorTests
    {
        private readonly DemeritPointsCalculator _calculator;

        public DemeritPointsCalculatorTests()
        {
            _calculator = new DemeritPointsCalculator();
        }

        [Theory]
        [InlineData(301)]
        [InlineData(-1)]
        public void CalculateDemeritPoints_ThrowArgumentOutOfRangeException_WhenSpeedIsLowerThan0AndHigherThanMaxSpeed(int speed)
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateDemeritPoints(speed));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(65, 0)]
        [InlineData(69, 0)]
        [InlineData(70, 1)]
        [InlineData(75, 2)]
        public void CalculateDemeritPoints_ReturnDemeritPoints_WhenSpeedIsValid(int speed, int expectedResult)
        {
            //Act
            var result = _calculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
