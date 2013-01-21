namespace VSPRInterfaces
{
    using System;
    using VSPRCommon;
    using VSPRCommon.EventArguments;

    public interface IRenameService
    {
        event EventHandler<RenameFinishedEventArgs> RenameFinished;
        void InvokeRenameFinished(RenameFinishedEventArgs args);
        void Rename(RenameContext renameContext);
    }
}