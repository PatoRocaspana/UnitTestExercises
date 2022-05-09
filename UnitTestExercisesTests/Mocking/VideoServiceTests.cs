using Moq;
using System.Collections.Generic;
using TestNinja.Mocking;
using UnitTestExercises.Mocking;
using Xunit;
using static TestNinja.Mocking.VideoService;

namespace UnitTestExercisesTests.Mocking
{
    public class VideoServiceTests
    {
        private readonly VideoService _videoService;
        private readonly Mock<IFileReader> _mockFileReader;
        private readonly Mock<IVideoRepository> _mockRepository;

        public VideoServiceTests()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_mockFileReader.Object, _mockRepository.Object);
        }

        [Fact]
        public void ReadVideoTitle_ReturnError_WhenFileIsEmpty()
        {
            //Arrange
            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            //Act
            var result = _videoService.ReadVideoTitle();

            //Assert
            Assert.Contains("error", result.ToLower());
        }

        [Fact]
        public void GetUnprocessedVideosAsCsv_ReturnEmptyString_ThereIsNotVideosUnprocessed()
        {
            //Arrange
            var unprocessedVideosList = new List<Video>();
            _mockRepository.Setup(r => r.GetUnprocessedVideos()).Returns(unprocessedVideosList);

            //Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            //Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void GetUnprocessedVideosAsCsv_ReturnUnprocessedVideosIdsString_ThereIsVideosUnprocessed()
        {
            //Arrange
            var unprocessedVideosList = new List<Video>()
            {
                new Video {Id = 1},
                new Video {Id = 2}
            };
            _mockRepository.Setup(r => r.GetUnprocessedVideos()).Returns(unprocessedVideosList);

            //Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            //Assert
            Assert.Equal("1,2", result);
        }
    }
}
