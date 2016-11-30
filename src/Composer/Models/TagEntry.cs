using System.IO;
using Blamite.Blam;

namespace Composer.Models
{
	public class TagEntry
	{
		public TagEntry(ITag rawTag, string className, string name, string tagFileName, string directory)
		{
			RawTag = rawTag;
			ClassName = className;
			Name = name;
			TagFileName = tagFileName;
			Directory = directory;
			FullPath = Path.Combine(Directory, TagFileName);
		}

		public ITag RawTag { get; set; }

		public string ClassName { get; set; }

		public string TagFileName { get; set; }

		public string Directory { get; set; }

		public string Name { get; set; }

		public string FullPath { get; set; }
	}
}
