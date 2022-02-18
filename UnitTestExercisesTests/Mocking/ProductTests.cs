using Moq;
using TestNinja.Mocking;
using Xunit;

namespace UnitTestExercisesTests.Mocking
{
    public class ProductTests
    {
        [Fact]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            //Arrange
            var product = new Product { ListPrice = 100 };

            //Act
            var result = product.GetPrice(new Customer { IsGold = true });

            //Assert
            Assert.Equal(70, result);
        }

        [Fact]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount2() //Mock Abuse
        {
            //Arrange
            var mockCustomer = new Mock<ICustomer>();
            mockCustomer.Setup(c => c.IsGold).Returns(true);
            var product = new Product { ListPrice = 100 };

            //Act
            var result = product.GetPrice(mockCustomer.Object);

            //Assert
            Assert.Equal(70, result);
        }
    }
}
