namespace VSPRInterfaces
{
    public interface IConfiguration
    {
        string ApplicationName { get; }
        string InstalledVersion { get; }
        string ReferenceAssembly { get; set; }
    }
}