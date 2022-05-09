using Moq;
using TestNinja.Mocking;
using Xunit;

namespace UnitTestExercisesTests.Mocking
{
    public class OrderServiceTests
    {
        [Fact]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            //Arrange
            var mockStorage = new Mock<IStorage>();
            var service = new OrderService(mockStorage.Object);

            //Act
            var order = new Order();
            service.PlaceOrder(order);

            //Assert
            mockStorage.Verify(s => s.Store(order));
        }
    }
}
