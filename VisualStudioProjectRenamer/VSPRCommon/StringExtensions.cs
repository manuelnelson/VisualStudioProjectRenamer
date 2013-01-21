namespace VSPRCommon
{
    public static class StringExtensions
    {
        public static bool ContainsValidProjectExtension(this string self)
        {
            return self.Contains(".csproj") || self.Contains(".vbproj") || self.Contains(".vcxproj");            
        }
    }
}
