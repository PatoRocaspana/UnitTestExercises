using System.Net;

namespace UnitTestExercises.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string source, string storagePlace);
    }

    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string source, string destinationPath)
        {
            var client = new WebClient();
            client.DownloadFile(source, destinationPath);
        }
    }
}
