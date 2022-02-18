using TestNinja.Fundamentals;
using Xunit;

namespace UnitTestExercisesTests.Fundamentals
{
    public class FizzBuzzTests
    {
        [Fact]
        public void GetOutput_ReturnFizz_WhenNumberIsDivisibleBy3()
        {
            //Act
            var result = FizzBuzz.GetOutput(3);

            //Result
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void GetOutput_ReturnBuzz_WhenNumberIsDivisibleBy5()
        {
            //Act
            var result = FizzBuzz.GetOutput(5);

            //Result
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void GetOutput_ReturnFizzBuzz_WhenNumberIsDivisibleBy3And5()
        {
            //Act
            var result = FizzBuzz.GetOutput(15);

            //Result
            Assert.Equal("FizzBuzz", result);
        }

        [Fact]
        public void GetOutput_ReturnSameNumber_WhenNumberIsNotDivisibleBy3And5()
        {
            //Act
            var result = FizzBuzz.GetOutput(1);

            //Result
            Assert.Equal("1", result);
        }
    }
}
