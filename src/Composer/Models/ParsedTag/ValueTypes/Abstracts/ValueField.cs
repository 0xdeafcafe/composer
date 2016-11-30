using Newtonsoft.Json;

namespace Composer.Models.ParsedTag.ValueTypes.Abstracts
{
	public abstract class ValueField : DataField
	{
		[JsonProperty("name")]
		private string Name { get; set; }

		[JsonProperty("offset")]
		private uint Offset { get; set; }

		[JsonProperty("address")]
		public uint Address { get; set; }

		public ValueField(string name, uint offset, uint address)
		{
			Name = name;
			Offset = offset;
			Address = address;
		}
	}
}
