using TestNinja.Fundamentals;
using Xunit;

namespace UnitTestExercisesTests.Fundamentals
{
    public class MathTests
    {
        private readonly Math _math;

        public MathTests()
        {
            _math = new Math();
        }

        [Fact]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //Act
            var result = _math.Add(1, 2);

            //Assert
            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(2, 1, 2)]
        [InlineData(1, 2, 2)]
        [InlineData(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            //Act
            var result = _math.Max(a, b);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            //Act
            var result = _math.GetOddNumbers(5);

            //Assert
            Assert.Equal(new[] { 1, 3, 5 }, result);
        }
    }
}
