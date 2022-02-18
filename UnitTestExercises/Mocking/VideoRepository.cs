using static TestNinja.Mocking.VideoService;

namespace UnitTestExercises.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }

    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideos()
        {
            using (var context = new VideoContext())
            {
                var videos = context.Videos.Where(x => x.IsProcessed == false)
                                           .ToList();

                return videos;
            }
        }
    }
}
