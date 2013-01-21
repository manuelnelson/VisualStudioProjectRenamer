namespace VSPRCommon
{
    using System.Collections.Generic;

    public class Language
    {
        private readonly IList<string> languages;

        public Language()
        {
            languages = new List<string>();
        }

        public IList<string> GetLanguages()
        {
            languages.Add("de-DE");
            languages.Add("en-US");

            return languages;
        }
    }
}