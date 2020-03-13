using SoftAssert;
using SoftAssert.Enums;
using System;
using System.Collections;

namespace SoftAssertTests.AssertStubs
{
	/// <summary>
	/// This class is an implemaantation of abstract class <see cref="OneParamAssert{T}"/> 
	/// created only for testing purposes and has only stubs for abstract methods.
	/// Don't use it anywhere else.
	/// </summary>
	/// <typeparam name="T">Type of assert param</typeparam>
	internal class OneParamAssertStub<T> : OneParamAssert<T>
	{
		public OneParamAssertStub(OneParamAssertTypes type, T param, string message = null) : base(type, param, message) { }
		public override void IsEmpty(ICollection collection, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsFalse(bool condition, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsNegative(T numeric, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsNotEmpty(ICollection collection, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsNotNull(object anObject, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsNotZero(T numeric, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsNull(object anObject, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsPositive(T numeric, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsTrue(bool condition, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void IsZero(T numeric, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void That(bool condition, string message = null)
		{
			throw new NotImplementedException();
		}

		public override void That(Func<bool> condition, string message = null)
		{
			throw new NotImplementedException();
		}
	}
}
