using Blamite.Plugins;
using Newtonsoft.Json;

namespace Composer.Models.ParsedTag
{
	public class TagRevision
	{
		public TagRevision() { }

		public TagRevision(PluginRevision revision)
		{
			Author = revision.Researcher;
			Version = revision.Version;
			Description = revision.Description;
		}

		[JsonProperty("author")]
		public string Author { get; set; }

		[JsonProperty("version")]
		public int Version { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }
	}
}
