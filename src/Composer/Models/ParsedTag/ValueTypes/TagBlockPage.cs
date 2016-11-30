using Composer.Models.ParsedTag.ValueTypes.Abstracts;
using Newtonsoft.Json;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class TagBlockPage
	{
		[JsonProperty("fields")]
		public DataField[] Fields { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		public TagBlockPage(int index, int size)
		{
			Index = index;
			Fields = new DataField[size];
		}
	}
}
