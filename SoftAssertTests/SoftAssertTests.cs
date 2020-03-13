using Moq;
using NUnit.Framework;
using SoftAssert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftAssertTests
{
	[TestFixture]
	public class SoftAssertTests
	{
		SoftAssert.SoftAssert softAssert;
		AssertionInfo assertionInfo = new AssertionInfo("My assert", "My message");

		[SetUp]
		public void TestSetUp()
		{
			/*SoftAssertSettings settings = new SoftAssertSettings();

			softAssert = new SoftAssert.SoftAssert(settings);*/
		}

		[TearDown]
		public void TestTearDown()
		{
			//var positiveAsserts = softAssert.GetPositiveAsserts();
			//var negativeAsserts = softAssert.GetNegativeAsserts();
			//var inconclusiveAsserts = softAssert.GetNegativeAsserts();
		}


		[Test]
		[TestCaseSource(typeof(TestCaseDataGenerator), nameof(TestCaseDataGenerator.GetAssertParams))]
		public void VerifyAssertionTypeIsCorrect(Enum assertType, List<object> assertParams)
		{
			var assertMock = CreateAssert(assertType, assertParams);
			AssertionResult assertionResult = new AssertionResult(assertMock.Object, assertionInfo);
			var resultString = assertionResult.ToString();
			Assert.True(resultString.Contains($"Assertion Type: {assertType}"), "Assert Result has wrong assert type!");
		}

		[Test]
		[TestCaseSource(typeof(TestCaseDataGenerator), nameof(TestCaseDataGenerator.GetAssertParams))]
		public void VerifyAssertionResultStateIsCorrect(Enum assertType, List<object> assertParams)
		{
			var assertMock = CreateAssert(assertType, assertParams);
			AssertionResult assertionResult = new AssertionResult(assertMock.Object, assertionInfo);
			var resultString = assertionResult.ToString();
			Assert.True(resultString.Contains($"Result: {AssertionResults.Inconclusive}"), "Assert Result has wrong assert state!");
		}

		[Test]
		[TestCaseSource(typeof(TestCaseDataGenerator), nameof(TestCaseDataGenerator.GetAssertParams))]
		public void VerifyAssertionParamsAreCorrect(Enum assertType, List<object> assertParams)
		{
			var assertMock = CreateAssert(assertType, assertParams);
			AssertionResult assertionResult = new AssertionResult(assertMock.Object, assertionInfo);
			var resultString = assertionResult.ToString();
			Assert.True(resultString.Contains("Assertion params"), "Assert Params line is missing!");
			int assertionParamsStringStart = resultString.IndexOf("Assertion params");
			int assertionNameStringStart = resultString.LastIndexOf("Assertion name");
			resultString = resultString.Substring(assertionParamsStringStart, assertionNameStringStart - assertionParamsStringStart);
			int expectedParamsCount = assertMock.Object.GetAssertParams().Count();
			int typeOccurencesCount = Regex.Matches(resultString, "Type").Count;
			int valueOccurencesCount = Regex.Matches(resultString, "Value").Count;
			Assert.AreEqual(expectedParamsCount, typeOccurencesCount, "Assert Result has wrong amount of 'Type' occurences!");
			Assert.AreEqual(expectedParamsCount, valueOccurencesCount, "Assert Result has wrong amount of 'Value' occurences!");
		}

		[Test]
		[TestCaseSource(typeof(TestCaseDataGenerator), nameof(TestCaseDataGenerator.GetAssertParams))]
		public void VerifyAssertionNameIsCorrect(Enum assertType, List<object> assertParams)
		{
			var assertMock = CreateAssert(assertType, assertParams);
			AssertionResult assertionResult = new AssertionResult(assertMock.Object, assertionInfo);
			var resultString = assertionResult.ToString();
			Assert.True(resultString.Contains($"Assertion name: {assertionInfo.Name}"), "Assert Result has wrong assert name!");
		}

		private Mock<IAssertable> CreateAssert(Enum assertType, List<object> assertParams)
		{
			var mock = new Mock<IAssertable>();
			mock.Setup(a => a.GetAssertType()).Returns(assertType.ToString());
			mock.Setup(a => a.GetAssertParams()).Returns(assertParams);
			return mock;
		}
	}
}