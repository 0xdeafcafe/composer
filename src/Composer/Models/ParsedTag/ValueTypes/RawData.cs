using Composer.Models.ParsedTag.ValueTypes.Abstracts;
using Newtonsoft.Json;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class RawData : ValueField
	{
		[JsonProperty("data_address")]
		public uint DataAddress { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("format")]
		public string Format { get; set; }

		[JsonProperty("length")]
		public int Length { get; set; }

		public RawData(string name, uint offset, uint address, string value, int length)
			: base(name, offset, address)
		{
			Value = value;
			Length = length;
		}

		public RawData(string name, uint offset, string format, uint address, string value, int length)
			: base(name, offset, address)
		{
			Value = value;
			Length = length;
			Format = format;
		}
	}
}
