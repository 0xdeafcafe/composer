using Newtonsoft.Json;

namespace Composer.Models
{
	public class ProjectProperties
	{
		[JsonProperty("tags_folder")]
		public string TagsFolder { get; set; }

		[JsonProperty("git_enabled")]
		public bool GitEnabled { get; set; }
    }
}
