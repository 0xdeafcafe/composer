using Composer.Models.ParsedTag.ValueTypes.Abstracts;
using Newtonsoft.Json;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class CommentData : DataField
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		public CommentData(string name, string text)
		{
			Name = name;
			Text = text;
		}
	}
}
