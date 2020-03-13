using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftAssert
{
	public class AssertionResult
	{ 
		public IAssertable Assert { get; private set; }
		public AssertionInfo AssertionInfo { get; private set; }

		public AssertionResult(IAssertable assert, AssertionInfo assertionInfo)
		{
			Assert = assert;
			AssertionInfo = assertionInfo;
		}

		public override string ToString()
		{
			string assertionName = $" Assertion name: {AssertionInfo.Name ?? "None"}";
			return $"Result: {AssertionInfo.Result}, Assertion Type: {Assert.GetAssertType()}, Assertion params: {GetAssertionParamsString()}{assertionName}.";
		}

		private string GetAssertionParamsString()
		{
			var sb = new StringBuilder();
			string paramLine = "Type: {0}, Value: {1}; ";
			var assertParams = Assert.GetAssertParams();
			if (assertParams.Count() == 0)
			{
				return "None; ";
			}
			foreach (var p in assertParams)
			{
				string line = string.Format(paramLine, (p ?? new object()).GetType(), p);
				sb.Append(line);
			}
			return sb.ToString().Trim();
		}
	}
}
