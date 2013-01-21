namespace VSPRCommon
{
    using System;

    [Serializable]
    public class Proxy
    {
        public string Url { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Url) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Username);
            }
        }
    }
}