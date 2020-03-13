using System;
using System.Collections.Generic;

namespace SoftAssert
{
	public interface IAssertable
	{
		/// <summary>
		/// Returns type of assertion <see cref="BaseAssert{T}.AssertType"/>
		/// </summary>
		/// <returns>String with type of assertion (AreEqual, IsNull, True, False, etc)</returns>
		string GetAssertType();

		/// <summary>
		/// This method will perform assertion for specified params.
		/// It's implementation is similar to fabric so you just need 
		/// to implement some abstract methods which will call assertions
		/// from Unit test framework you use (nUnit, MSTest, etc.)
		/// </summary>
		void Assert();

		/// <summary>
		/// Returns all params that were received by current Assertion
		/// </summary>
		/// <returns>IEnumerable of all pairs (param name, param value) for current assert</returns>
		IEnumerable<object> GetAssertParams();
	}
}