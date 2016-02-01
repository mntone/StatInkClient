using System;

namespace Mntone.StatInk
{
	public sealed class StatInkClientException : Exception
	{
		public StatInkClientException(string message)
			: base(message)
		{ }

		public StatInkClientException(string message, Exception innerException)
			: base(message, innerException)
		{ }
	}
}