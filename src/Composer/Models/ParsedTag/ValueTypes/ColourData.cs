using Composer.Models.ParsedTag.ValueTypes.Abstracts;
using Newtonsoft.Json;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class ColourData : ValueField
	{
		[JsonProperty("data_type")]
		public string DataType;

		[JsonProperty("format")]
		public string Format;

		[JsonProperty("value")]
		public string Value;

		public ColourData(string name, uint offset, uint address, string format, string dataType, string value)
			: base(name, offset, address)
		{
			DataType = dataType;
			Format = format;
			Value = value;
		}
	}
}
