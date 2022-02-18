using TestNinja.Fundamentals;
using Xunit;

namespace UnitTestExercisesTests.Fundamentals
{
    public class ReservationTests
    {
        [Fact]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanBeCancelledBy_SameUserCancelling_ReturnTrue()
        {
            //Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnFalse()
        {
            //Arrange
            var reservation = new Reservation { MadeBy = new User() };

            //Act
            var result = reservation.CanBeCancelledBy(new User());

            //Assert
            Assert.False(result);
        }
    }
}
