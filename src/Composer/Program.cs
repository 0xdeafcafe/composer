using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using Composer.Commands.Project;
using Composer.Exceptions;
using Didact;

namespace Composer
{
	public class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				new DidactClient()
					.CliName("composer")
					.Name("Composer Cache Editor")
					.Version("1.0.0")
					.Option("-t, --test [yaas]", "test")
					.CommandAsync("new <cache> <project>", "Creates a new composer project from a cache file", ComposerProject.Create)

					.ParseAsync(args).Wait();
			}
			catch (AggregateException ex)
			{
				var innerException = ExceptionDispatchInfo.Capture(ex.Flatten().InnerExceptions.First());

				if (innerException.SourceException is ComposerException)
					Console.WriteLine($"{ex.Message}");
				else
					innerException.Throw();
			}
		}
	}
}
