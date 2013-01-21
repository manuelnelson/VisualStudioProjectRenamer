namespace VSPRBase.Common
{
    using System;
    using System.IO;
    using VSPRInterfaces;

    internal sealed class Guard : IGuard
    {
        public void DirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new ArgumentException(directory);
            }
        }

        public void FileExists(string file)
        {
            if (!File.Exists(file))
            {
                throw new ArgumentException(file);
            }
        }

        public void IsNotNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(value);
            }
        }
    }
}