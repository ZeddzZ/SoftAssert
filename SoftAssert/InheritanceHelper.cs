using System;
using System.Linq;

namespace SoftAssert
{
	public static class InheritanceHelper
	{
		/// <summary>
		///  Checks if specified instance has specified type or type of one of its descendants
		/// </summary>
		/// <param name="objectToCheck">Item that should be checked</param>
		/// <param name="objectToBe">Items with type that should be objectToCheck (or one of its parents)</param>
		/// <returns>True if objectToBe is of type objectToCheck or one of its parents, false if not</returns>
		public static bool IsDescendantOrSelf(object objectToCheck, object objectToBe)
		{
			return IsDescendantOrSelf(objectToCheck.GetType(), objectToBe.GetType());
		}

		/// <summary>
		///  Checks if specified instance has specified type or type of one of its descendants
		/// </summary>
		/// <param name="objectToCheck">Item that should be checked</param>
		/// <param name="typeToBe">Type that should be objectToCheck (or one of its parents)</param>
		/// <returns>True if objectToBe is of type objectToCheck or one of its parents, false if not</returns>
		public static bool IsDescendantOrSelf(object objectToCheck, Type typeToBe)
		{
			return IsDescendantOrSelf(objectToCheck.GetType(), typeToBe);
		}

		/// <summary>
		///  Checks if specified instance has specified type or type of one of its descendants
		/// </summary>
		/// <param name="typeToCheck">Type that should be checked</param>
		/// <param name="objectToBe">Items with type that should be objectToCheck (or one of its parents)</param>
		/// <returns>True if objectToBe is of type objectToCheck or one of its parents, false if not</returns>
		public static bool IsDescendantOrSelf(Type typeToCheck, object objectToBe)
		{
			return IsDescendantOrSelf(typeToCheck, objectToBe.GetType());
		}

		/// <summary>
		///  Checks if specified instance has specified type or type of one of its descendants
		/// </summary>
		/// <param name="objectToCheck">Type that should be checked</param>
		/// <param name="objectToBe">Type that should be objectToCheck (or one of its parents)</param>
		/// <returns>True if objectToBe is of type objectToCheck or one of its parents, false if not</returns>
		public static bool IsDescendantOrSelf(Type typeToCheck, Type typeToBe)
		{
			return typeToCheck.IsAssignableFrom(typeToBe);
		}

		/// <summary>
		/// Checks if specified instance implements interface
		/// </summary>
		/// <param name="objectToCheck">Object to be checked</param>
		/// <param name="typeToBe">Interface that shopuld be implemented</param>
		/// <returns>True if item implements specified interface, false if not</returns>
		public static bool IsInterfaceImplemented(object objectToCheck, Type typeToBe)
		{
			return IsInterfaceImplemented(objectToCheck.GetType(), typeToBe);
		}

		/// <summary>
		/// Checks if specified instance implements interface
		/// </summary>
		/// <param name="objectToCheck">Type to be checked</param>
		/// <param name="typeToBe">Interface that shopuld be implemented</param>
		/// <returns>True if item implements specified interface, false if not</returns>
		public static bool IsInterfaceImplemented(Type typeToCheck, Type typeToBe)
		{
			return typeToCheck.GetInterfaces().Contains(typeToBe);
		}
	}
}
