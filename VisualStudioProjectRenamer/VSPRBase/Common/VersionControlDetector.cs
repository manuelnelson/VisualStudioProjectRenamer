namespace VSPRBase.Common
{
	using VSPRCommon.Enums;
	using VSPRInterfaces;

	internal class VersionControlDetector : IVersionControlDetector
	{
		public VersionControlSystem Detect()
		{
			// TODO NKO: Implement version control system detection.
			return VersionControlSystem.SVN;
		}
	}
}