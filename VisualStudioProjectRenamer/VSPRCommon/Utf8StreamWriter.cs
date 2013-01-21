namespace VSPRCommon
{
    using System.IO;
    using System.Text;

    public class Utf8StreamWriter : StreamWriter
    {
        public Utf8StreamWriter(string file) : base(file)
        {
        }

        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}