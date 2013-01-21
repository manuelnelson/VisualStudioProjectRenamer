namespace VSPRInterfaces
{
    using System.Windows.Forms;

    public interface IDownloader
    {
        IAppCast DownloadAppCast(string appCastUrl, IConfiguration configuration);
        void DownloadUpdate(IAppCast appcast,string fileName, Form form);
    }
}