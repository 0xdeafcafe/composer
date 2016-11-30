using Newtonsoft.Json;

namespace Composer.Models
{
	public class Project
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("version")]
		public string Version { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("properties")]
		public ProjectProperties Properties { get; set; } = new ProjectProperties();
	}
}
