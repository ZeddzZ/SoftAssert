using System;

namespace SoftAssert
{
	public class AssertionInfo
	{
		public string Name { get; }
		public AssertionResults Result { get; set; }
		public Exception AssertException { get; set; }
		public string CustomMessage { get; set; }

		public AssertionInfo() : this("") { }

		public AssertionInfo(string name, string customMessage = null)
		{
			Name = name;
			CustomMessage = customMessage;
			Result = AssertionResults.Inconclusive;
			AssertException = null;
		}
	}
}
