﻿using Newtonsoft.Json;
using System.Data.Entity;
using UnitTestExercises.Mocking;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader _fileReader;
        private readonly IVideoRepository _repository;

        public VideoService(IFileReader fileReader, IVideoRepository repository)
        {
            _fileReader = fileReader;
            _repository = repository;
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = _repository.GetUnprocessedVideos();
            foreach (var v in videos)
                videoIds.Add(v.Id);

            var UnprocessedVideosAsCsv = string.Join(",", videoIds);
            return UnprocessedVideosAsCsv;
        }

        public class Video
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public bool IsProcessed { get; set; }
        }

        public class VideoContext : DbContext
        {
            public DbSet<Video> Videos { get; set; }
        }
    }
}
