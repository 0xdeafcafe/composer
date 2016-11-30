using System.Linq;

namespace Composer.Helpers
{
	public static class PlatformHelpers
	{
		public static readonly char[] DisallowedPluginChars =
		{
			'>', '<', ':', '/', '\\', '&', ';', '?', '|', '*', '"'
		};

		public static string EscapePath(string path)
		{
			return DisallowedPluginChars.Aggregate(path,
				(current, disallowed) => current.Replace(disallowed, '_'));
		}
	}
}
