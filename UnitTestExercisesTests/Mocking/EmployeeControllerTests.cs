using Moq;
using UnitTestExercises.Mocking;
using Xunit;

namespace UnitTestExercisesTests.Mocking
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepository;
        private readonly EmployeeController _employeeController;

        public EmployeeControllerTests()
        {
            _mockRepository = new Mock<IEmployeeRepository>();
            _mockRepository.Setup(r => r.DeleteEmployee(1));
            _employeeController = new EmployeeController(_mockRepository.Object);
        }

        [Fact]
        public void DeleteEmployee_RemoveEmployee_WhenIsCalled()
        {
            //Act
            _employeeController.DeleteEmployee(1);

            //Assert
            _mockRepository.Verify(r => r.DeleteEmployee(1), Times.Once());
        }

        [Fact]
        public void DeleteEmployee_ReturnRedirectResult_WhenIsCalled()
        {
            //Act
            var result = _employeeController.DeleteEmployee(1);

            //Assert
            Assert.IsType<RedirectResult>(result);
        }
    }
}
