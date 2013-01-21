namespace VSPRCommon
{
    public sealed class RenameContext
    {
        public bool RenameMainEntryFile { get; set; }
        public string Solution { get; set; }
        public Project OldProject { get; set; }
        public Project NewProject { get; set; }
        public bool IsUnderVersionControl { get; set; }
        public bool CommitChanges { get; set; }
        public bool AdjustFolderNameProjectNameMissmatch { get; set; }
    }
}
