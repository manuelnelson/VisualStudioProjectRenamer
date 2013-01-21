namespace VSPRBase.Services
{
    using Common;
    using VSPRInterfaces;

    internal sealed class UpdateService : IUpdateService
    {
        private readonly IUpdater updater;

        public UpdateService(IUpdater updater)
        {
            this.updater = updater;

            this.updater.AppCastUrl = Constants.UpdateUrl;
            this.updater.ShowDiagnosticWindow = true;
            this.updater.TrustEverySSLConnection = true;
        }

        public void CheckForUpdate()
        {
            updater.GetUpdate();
        }
    }
}