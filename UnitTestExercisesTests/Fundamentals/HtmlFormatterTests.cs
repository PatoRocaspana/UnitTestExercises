using TestNinja.Fundamentals;
using Xunit;

namespace UnitTestExercisesTests.Fundamentals
{
    public class HtmlFormatterTests
    {
        [Fact]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            //Arrange
            var formatter = new HtmlFormatter();

            //Act
            var result = formatter.FormatAsBold("abc");

            //Assert
            Assert.Equal("<strong>abc</strong>", result.ToLower());

            Assert.StartsWith("<strong>", result.ToLowerInvariant());
            Assert.EndsWith("</strong>", result.ToLowerInvariant());
            Assert.Contains("abc", result);
        }
    }
}
