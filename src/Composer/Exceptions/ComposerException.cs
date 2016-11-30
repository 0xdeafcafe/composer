using System;

namespace Composer.Exceptions
{
	public class ComposerException : Exception
	{
		public ComposerException(string message) : base(message) { }
	}
}
