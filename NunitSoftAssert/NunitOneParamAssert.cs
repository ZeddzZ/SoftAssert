using NUnit.Framework;
using SoftAssert;
using SoftAssert.Enums;
using System;
using System.Collections;
using assert = NUnit.Framework.Assert;

namespace NunitSoftAssert
{
	class NunitOneParamAssert<T> : OneParamAssert<T>
	{
		public NunitOneParamAssert(OneParamAssertTypes assertType, T firstParam, string message = null)
			: base(assertType, firstParam, message) { }
		
		public override void IsEmpty(ICollection collection, string message = null)
		{
			assert.IsEmpty(collection, message);
		}

		public override void IsFalse(bool condition, string message = null)
		{
			assert.IsFalse(condition, message);
		}

		public override void IsNegative(T numeric, string message = null)
		{
			switch (numeric)
			{
				case int intParam:
					assert.Negative(intParam, message);
					break;
				case uint uintParam:
					assert.Negative(uintParam, message);
					break;
				case double doubleParam:
					assert.Negative(doubleParam, message);
					break;
				case long longParam:
					assert.Negative(longParam, message);
					break;
				case ulong ulongParam:
					assert.Negative(ulongParam, message);
					break;
				case float floatParam:
					assert.Negative(floatParam, message);
					break;
				case decimal decimalParam:
					assert.Negative(decimalParam, message);
					break;
				case short shortParam:
					assert.Negative(shortParam, message);
					break;
				case byte byteParam:
					assert.Negative(byteParam, message);
					break;
			}
		}

		public override void IsNotEmpty(ICollection collection, string message = null)
		{
			assert.IsNotEmpty(collection, message);
		}

		public override void IsNotNull(object anObject, string message = null)
		{
			assert.IsNotNull(anObject, message);
		}

		public override void IsNotZero(T numeric, string message = null)
		{
			switch (numeric)
			{
				case int intParam:
					assert.NotZero(intParam, message);
					break;
				case uint uintParam:
					assert.NotZero(uintParam, message);
					break;
				case double doubleParam:
					assert.NotZero(doubleParam, message);
					break;
				case long longParam:
					assert.NotZero(longParam, message);
					break;
				case ulong ulongParam:
					assert.NotZero(ulongParam, message);
					break;
				case float floatParam:
					assert.NotZero(floatParam, message);
					break;
				case decimal decimalParam:
					assert.NotZero(decimalParam, message);
					break;
				case short shortParam:
					assert.NotZero(shortParam, message);
					break;
				case byte byteParam:
					assert.NotZero(byteParam, message);
					break;
			}
		}

		public override void IsNull(object anObject, string message = null)
		{
			assert.IsNull(anObject, message);
		}

		public override void IsPositive(T numeric, string message = null)
		{
			switch (numeric)
			{
				case int intParam:
					assert.Positive(intParam, message);
					break;
				case uint uintParam:
					assert.Positive(uintParam, message);
					break;
				case double doubleParam:
					assert.Positive(doubleParam, message);
					break;
				case long longParam:
					assert.Positive(longParam, message);
					break;
				case ulong ulongParam:
					assert.Positive(ulongParam, message);
					break;
				case float floatParam:
					assert.Positive(floatParam, message);
					break;
				case decimal decimalParam:
					assert.Positive(decimalParam, message);
					break;
				case short shortParam:
					assert.Positive(shortParam, message);
					break;
				case byte byteParam:
					assert.Positive(byteParam, message);
					break;
			}
		}

		public override void IsTrue(bool condition, string message = null)
		{
			assert.IsTrue(condition, message);
		}

		public override void IsZero(T numeric, string message = null)
		{
			switch (numeric)
			{
				case int intParam:
					assert.Zero(intParam, message);
					break;
				case uint uintParam:
					assert.Zero(uintParam, message);
					break;
				case double doubleParam:
					assert.Zero(doubleParam, message);
					break;
				case long longParam:
					assert.Zero(longParam, message);
					break;
				case ulong ulongParam:
					assert.Zero(ulongParam, message);
					break;
				case float floatParam:
					assert.Zero(floatParam, message);
					break;
				case decimal decimalParam:
					assert.Zero(decimalParam, message);
					break;
				case short shortParam:
					assert.Zero(shortParam, message);
					break;
				case byte byteParam:
					assert.Zero(byteParam, message);
					break;
			}
		}

		public override void That(bool condition, string message = null)
		{
			assert.That(condition, message);
		}

		public override void That(Func<bool> condition, string message = null)
		{
			assert.That(condition, message);
		}

		public override Exception Throws(T code, string message = null)
		{
			if (InheritanceHelper.IsDescendantOrSelf(code, typeof(TestDelegate)))
			{
				return assert.Throws<Exception>(code as TestDelegate, message);
			} else
			{
				throw new ArgumentException("Wrong arguments received for specified assert!");
			}
		}

		public override Exception ThrowsAsync(T code, string message = null)
		{
			if (InheritanceHelper.IsDescendantOrSelf(code, typeof(AsyncTestDelegate)))
			{
				return assert.ThrowsAsync<Exception>(code as AsyncTestDelegate, message);
			}
			else
			{
				throw new ArgumentException("Wrong arguments received for specified assert!");
			}
		}
	}
}
