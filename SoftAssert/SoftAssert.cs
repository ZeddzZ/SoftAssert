using SoftAssert.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SoftAssert
{
	public class SoftAssert
	{
		IList<AssertionResult> Assertions { get; set; }
		public SoftAssertSettings Settings { get; private set; }

		public SoftAssert() : this(new SoftAssertSettings()) { }

		public SoftAssert(SoftAssertSettings settings)
		{
			Settings = settings;
		}

		/*public void Assert<T>(OneParamAssertTypes AssertType, T param, AssertionInfo assertion)
		{
			IAssertable assert = getAssertFromParams(AssertType, param, assertion);
			var result = GetAssertResult(assert, assertion);
			Assertions.Add(result);
		}


		public void Assert<T>(TwoParamsAssertTypes AssertType, T firstParam, T secondParam, AssertionInfo assertion)
		{
			IAssertable assert = getAssertFromParams(AssertType, firstParam, secondParam, assertion);
			var result = GetAssertResult(assert, assertion);
			Assertions.Add(result);
		}

		public void Assert<T>(TwoParamsAssertWithDeltaTypes AssertType, double firstParam, double secondParam, double delta, AssertionInfo assertion)
		{
			IAssertable assert = getAssertFromParams(AssertType, firstParam, secondParam, delta, assertion);
			var result = GetAssertResult(assert, assertion);
			Assertions.Add(result);
		}


		public void Assert(ZeroParamAssertTypes AssertType, AssertionInfo assertion)
		{
			IAssertable assert = getAssertFromParams(AssertType, assertion);
			var result = GetAssertResult(assert, assertion);
			Assertions.Add(result);
		}*/

		protected AssertionResult GetAssertResult(IAssertable assert, AssertionInfo assertion)
		{
			var exception = DoAssert(assert);
			
			if (exception == null)
			{
				assertion.Result = AssertionResults.Passed;
				return new AssertionResult(assert, assertion);
			} else
			{
				assertion.Result = AssertionResults.Failed;
				assertion.AssertException = exception;
				ThrowExceptionIfNeeded(Settings.IsSoftAssertEnabled, exception);
				return new AssertionResult(assert, assertion);
			}
		}

		public IEnumerable<AssertionResult> GetPassedAsserts()
		{
			return GetSpecifiedAsserts(AssertionResults.Passed);
		}

		public IEnumerable<AssertionResult> GetFailedAsserts()
		{
			return GetSpecifiedAsserts(AssertionResults.Failed);
		}

		public IEnumerable<AssertionResult> GetInconclusiveAsserts()
		{
			return GetSpecifiedAsserts(AssertionResults.Inconclusive);
		}

		protected void LogAssertIfNeeded(IAssertable assert)
		{

		}

		protected void CreateScreenshotIfNeeded()
		{

		}

		private Exception DoAssert(IAssertable assert)
		{
			try
			{
				assert.Assert();
				return null;
			}
			catch (Exception e)
			{
				return e;
			}
		}

		private void ThrowExceptionIfNeeded(bool isNeededToThrow, Exception e)
		{
			if(isNeededToThrow)
			{
				throw e;
			}
		}

		private IEnumerable<AssertionResult> GetSpecifiedAsserts(AssertionResults result)
		{
			return Assertions.Where(el => el.AssertionInfo.Result == result);
		}
	}
}
