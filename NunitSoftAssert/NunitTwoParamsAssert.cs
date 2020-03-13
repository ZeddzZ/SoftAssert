using NUnit.Framework;
using NUnit.Framework.Constraints;
using SoftAssert;
using SoftAssert.Enums;
using System;
using System.Collections;
using assert = NUnit.Framework.Assert;

namespace NunitSoftAssert
{
	class NunitTwoParamsAssert<T1, T2> : TwoParamsAssert<T1, T2>
	{
		public NunitTwoParamsAssert(TwoParamsAssertTypes assertType, T1 firstParam, T2 secondParam, string message = null)
			: base(assertType, firstParam, secondParam, message) { }

		public override void AreEqual(object firstParam, object secondParam, string message = null)
		{
			assert.AreEqual(firstParam, secondParam, message);
		}

		public override void AreNotEqual(object firstParam, object secondParam, string message = null)
		{
			assert.AreNotEqual(firstParam, secondParam, message);
		}

		public override void AreNotSame(object firstParam, object secondParam, string message = null)
		{
			assert.AreNotSame(firstParam, secondParam, message);
		}

		public override void AreSame(object firstParam, object secondParam, string message = null)
		{
			assert.AreSame(firstParam, secondParam, message);
		}

		public override void Contains(object firstParam, ICollection secondParam, string message = null)
		{
			assert.Contains(firstParam, secondParam, message);
		}

		public override void Greater(IComparable firstParam, IComparable secondParam, string message = null)
		{
			assert.Greater(firstParam, secondParam, message);
		}

		public override void GreaterOrEqual(IComparable firstParam, IComparable secondParam, string message = null)
		{
			assert.GreaterOrEqual(firstParam, secondParam, message);
		}

		public override void IsAssignableFrom(Type firstParam, object secondParam, string message = null)
		{
			assert.IsAssignableFrom(firstParam, secondParam, message);
		}

		public override void IsInstanceOf(Type firstParam, object secondParam, string message = null)
		{
			assert.IsInstanceOf(firstParam, secondParam, message);
		}

		public override void IsNotAssignableFrom(Type firstParam, object secondParam, string message = null)
		{
			assert.IsNotAssignableFrom(firstParam, secondParam, message);
		}

		public override void IsNotInstanceOf(Type firstParam, object secondParam, string message = null)
		{
			assert.IsNotInstanceOf(firstParam, secondParam, message);
		}

		public override void Less(IComparable firstParam, IComparable secondParam, string message = null)
		{
			assert.Less(firstParam, secondParam, message);
		}

		public override void LessOrEqual(IComparable firstParam, IComparable secondParam, string message = null)
		{
			assert.LessOrEqual(firstParam, secondParam, message);
		}

		public override void NotContains(object firstParam, ICollection secondParam, string message = null)
		{
			throw new NotSupportedException("This assertion is not supported by nUnit or current implementation of this library");
		}

		public override void That(T1 firstParam, T2 secondParam, string message = null)
		{
			if (InheritanceHelper.IsDescendantOrSelf(firstParam, typeof(TestDelegate)) && InheritanceHelper.IsInterfaceImplemented(secondParam, typeof(IResolveConstraint)))
			{
				assert.That(firstParam as TestDelegate, (IResolveConstraint)secondParam, message);
			} else if (InheritanceHelper.IsInterfaceImplemented(secondParam, typeof(IResolveConstraint)))
			{
				assert.That(firstParam, (IResolveConstraint)secondParam, message);
			} else
			{
				throw new ArgumentException("Wrong arguments received for specified assert!");
			}
				
		}

		public override Exception Throws(T1 firstParam, T2 secondParam, string message = null)
		{
			if (InheritanceHelper.IsDescendantOrSelf(firstParam, typeof(Type)) && InheritanceHelper.IsDescendantOrSelf(secondParam, typeof(TestDelegate)))
			{
				return assert.Throws(firstParam as Type, secondParam as TestDelegate, message);
			}
			else if (InheritanceHelper.IsInterfaceImplemented(firstParam, typeof(IResolveConstraint)) && InheritanceHelper.IsDescendantOrSelf(secondParam, typeof(TestDelegate)))
			{
				return assert.Throws((IResolveConstraint)firstParam, secondParam as TestDelegate, message);
			} else
			{
				throw new ArgumentException("Wrong arguments received for specified assert!");
			}
		}

		public override Exception ThrowsAsync(T1 firstParam, T2 secondParam, string message = null)
		{
			if (InheritanceHelper.IsDescendantOrSelf(firstParam, typeof(Type)) && InheritanceHelper.IsDescendantOrSelf(secondParam, typeof(AsyncTestDelegate)))
			{
				return assert.ThrowsAsync(firstParam as Type, secondParam as AsyncTestDelegate, message);
			}
			else if (InheritanceHelper.IsInterfaceImplemented(firstParam, typeof(IResolveConstraint)) && InheritanceHelper.IsDescendantOrSelf(secondParam, typeof(AsyncTestDelegate)))
			{
				return assert.ThrowsAsync((IResolveConstraint)firstParam, secondParam as AsyncTestDelegate, message);
			}
			else
			{
				throw new ArgumentException("Wrong arguments received for specified assert!");
			}
		}
	}
}
