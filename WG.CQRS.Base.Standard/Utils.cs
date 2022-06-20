using System;

namespace CQRS.Base.Standard
{
	internal static class Utils
	{
		internal static void MethodShouldBeImplemented(string methodName)
		{
			throw new NotImplementedException($"You should implement {methodName} in your interface implementation");
		}
	}
}
