namespace VSPRInterfaces
{
    public interface IGuard
    {
        void DirectoryExists(string directory);
        void FileExists(string file);
        void IsNotNullOrEmpty(string value);
    }
}