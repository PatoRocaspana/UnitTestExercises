using Moq;
using System.Net;
using TestNinja.Mocking;
using UnitTestExercises.Mocking;
using Xunit;

namespace UnitTestExercisesTests.Mocking
{
    public class InstallerHelperTests
    {
        private readonly Mock<IFileDownloader> _mockFileDownloader;
        private readonly InstallerHelper _installerHelper;
        private readonly string _customerName;
        private readonly string _installerName;

        public InstallerHelperTests()
        {
            _mockFileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_mockFileDownloader.Object);

            _customerName = "CustomerName";
            _installerName = "InstallerName";
        }

        [Fact]
        public void DownloadInstaller_ReturnTrue_DownloadIsSuccesful()
        {
            //Act
            var result = _installerHelper.DownloadInstaller(_customerName, _installerName);

            //Assert
            Assert.True(result);
            _mockFileDownloader.Verify(fw => fw.DownloadFile(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void DownloadInstaller_ReturnFalse_DownloadFails()
        {
            //Arrange
            _mockFileDownloader.Setup(x => x.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                           .Throws<WebException>();

            //Act
            var result = _installerHelper.DownloadInstaller(_customerName, _installerName);

            //Assert
            Assert.False(result);
            _mockFileDownloader.Verify(fw => fw.DownloadFile(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
