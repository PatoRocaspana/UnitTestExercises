using System;
using TestNinja.Fundamentals;
using Xunit;

namespace UnitTestExercisesTests.Fundamentals
{
    public class PhoneNumberTests
    {
        [Fact]
        public void ToString_ReturnFormatedString_WhenCalled()
        {
            //Arrange
            var number = "1234567891";
            var parsedNumber = PhoneNumber.Parse(number);

            //Act
            var stringFomattedNumber = parsedNumber.ToString();

            //Assert
            Assert.Contains(parsedNumber.Area, stringFomattedNumber);
            Assert.Contains(parsedNumber.Major, stringFomattedNumber);
            Assert.Contains(parsedNumber.Minor, stringFomattedNumber);
        }

        [Fact]
        public void Parse_ReturnPhoneNumber_WhenStringNumberIsValid()
        {
            //Arrange
            var number = "1234567891";

            //Act
            var parsedNumber = PhoneNumber.Parse(number);

            //Assert
            Assert.IsType<PhoneNumber>(parsedNumber);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Parse_ThrowArgumentException_WhenNumberIsNullOrWhiteSpace(string number)
        {
            //Act And Assert
            Assert.Throws<ArgumentException>(() => PhoneNumber.Parse(number));
        }

        [Theory]
        [InlineData("1")]
        [InlineData("12345")]
        [InlineData("12345123451")]
        public void Parse_ThrowArgumentException_WhenNumberLengthIsNotTen(string number)
        {
            //Act And Assert
            Assert.Throws<ArgumentException>(() => PhoneNumber.Parse(number));
        }
    }
}
