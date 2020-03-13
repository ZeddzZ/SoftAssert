
using SoftAssert;
using SoftAssert.Enums;
using System;
using System.Collections;

namespace SoftAssertTests.AssertStubs
{
	/// <summary>
	/// This class is an implemaantation of abstract class <see cref="TwoParamsAssert{T}"/> 
	/// created only for testing purposes and has only stubs for abstract methods.
	/// Don't use it anywhere else.
	/// </summary>
	/// <typeparam name="T1">Type of first assert param</typeparam>
	/// <typeparam name="T2">Type of second assert param</typeparam>
	internal class TwoParamsAssertStub<T1, T2> : TwoParamsAssert<T1, T2>
	{
		public TwoParamsAssertStub(TwoParamsAssertTypes assertType, T1 firstParam, T2 secondParam, string message = null) : base(assertType, firstParam, secondParam, message) { }

		public override void AreEqual(object firstParam, object secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void AreNotEqual(object firstParam, object secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void AreNotSame(object firstParam, object secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void AreSame(object firstParam, object secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void Contains(object firstParam, ICollection secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void Greater(IComparable firstParam, IComparable secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void GreaterOrEqual(IComparable firstParam, IComparable secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsAssignableFrom(Type firstParam, object secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsInstanceOf(Type firstParam, object secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsNotAssignableFrom(Type firstParam, object secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsNotInstanceOf(Type firstParam, object secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void Less(IComparable firstParam, IComparable secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void LessOrEqual(IComparable firstParam, IComparable secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void NotContains(object firstParam, ICollection secondParam, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void That(T1 firstParam, T2 secondParam, string message = null)
		{
			throw new NotImplementedException();
		}
	}
}
