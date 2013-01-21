namespace VSPRInterfaces
{
    public interface IInstaller
    {
        void Install(string fileName, IUpdater updaterInstance);
    }
}