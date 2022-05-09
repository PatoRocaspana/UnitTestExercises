using System.Net;
using UnitTestExercises.Mocking;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly IFileDownloader _fileDownloader;
        private string _setupDestinationFile;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            var source = string.Format($"http://example.com/{customerName}/{installerName}");
            try
            {
                _fileDownloader.DownloadFile(source, _setupDestinationFile);
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
