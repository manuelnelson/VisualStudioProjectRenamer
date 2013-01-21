namespace VSPRInterfaces
{
    using VSPRCommon.Enums;

    public interface IVersionControlDetector
    {
        VersionControlSystem Detect();
    }
}