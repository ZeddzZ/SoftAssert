namespace SoftAssert
{
	public class SoftAssertSettings
	{
		public bool IsSoftAssertEnabled { get; set; }
		public bool IsLogEnabled { get; set; }
		public ILogger Logger { get; set; }
		public bool IsScreenshotOnFailedAssertEnabled { get; set; }
		public IScreenshotTaker ScreenshotTaker { get; set; }

		public SoftAssertSettings() : this(true, false, null, false, null) { }

		public SoftAssertSettings(bool isSoftAssertEnabled, bool isLogEnabled, ILogger logger, bool isScreenshotOnFailedAssertEnabled, IScreenshotTaker screenshotTaker)
		{
			IsSoftAssertEnabled = isSoftAssertEnabled;
			IsLogEnabled = isLogEnabled;
			Logger = logger;
			IsScreenshotOnFailedAssertEnabled = isScreenshotOnFailedAssertEnabled;
			ScreenshotTaker = screenshotTaker;
		}		
	}
}
