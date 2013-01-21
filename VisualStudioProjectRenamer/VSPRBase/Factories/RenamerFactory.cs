namespace VSPRBase.Factories
{
    using Common;
    using VSPRInterfaces;

    internal sealed class RenamerFactory : IRenamerFactory
    {
        public IRenamer GetInstance(bool isUnderVersionControl)
        {
            return ServiceLocator.GetNamedInstance<IRenamer>(isUnderVersionControl ? Constants.SVNRenamer : Constants.StandardRenamer);
        }
    }
}