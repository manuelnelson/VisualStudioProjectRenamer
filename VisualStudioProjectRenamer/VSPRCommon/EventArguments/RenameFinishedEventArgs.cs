namespace VSPRCommon.EventArguments
{
    using System;

    public sealed class RenameFinishedEventArgs : EventArgs
    {
        public RenameFinishedEventArgs(bool finished, bool renameSuccessfull, bool rollbackSuccessfull)
        {
            Finished = finished;
            RenameSuccessfull = renameSuccessfull;
            RollbackSuccessfull = rollbackSuccessfull;
        }

        public bool Finished { get; private set; }

        public bool RenameSuccessfull { get; private set; }

        public bool RollbackSuccessfull { get; private set; }
    }
}