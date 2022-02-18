using System;
using TestNinja.Fundamentals;
using Xunit;

namespace UnitTestExercisesTests.Fundamentals
{
    public class DemeritPointsCalculatorTests
    {
        [Theory]
        [InlineData(301)]
        [InlineData(-1)]
        public void CalculateDemeritPoints_ThrowArgumentOutOfRangeException_WhenSpeedIsLowerThan0AndHigherThanMaxSpeed(int speed)
        {
            //Arrange
            var demeritPointsCalcular = new DemeritPointsCalculator();

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => demeritPointsCalcular.CalculateDemeritPoints(speed));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(65, 0)]
        [InlineData(69, 0)]
        [InlineData(70, 1)]
        [InlineData(75, 2)]
        public void CalculateDemeritPoints_ReturnDemeritPoints_WhenSpeedIsValid(int speed, int expectedResult)
        {
            //Arrange
            var calculator = new DemeritPointsCalculator();

            //Act
            var result = calculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
