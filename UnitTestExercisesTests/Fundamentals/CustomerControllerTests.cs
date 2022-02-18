using TestNinja.Fundamentals;
using Xunit;

namespace UnitTestExercisesTests.Fundamentals
{
    public class CustomerControllerTests
    {
        [Fact]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            //Arrange
            var controller = new CustomerController();

            //Act
            var result = controller.GetCustomer(0);

            //Assert
            Assert.IsType<NotFound>(result);
        }

        [Fact]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            //Arrange
            var controller = new CustomerController();

            //Act
            var result = controller.GetCustomer(1);

            //Assert
            Assert.IsType<Ok>(result);
        }
    }
}
