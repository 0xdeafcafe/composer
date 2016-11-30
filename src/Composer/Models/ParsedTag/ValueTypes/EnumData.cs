using Composer.Models.ParsedTag.ValueTypes.Abstracts;
using Newtonsoft.Json;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public enum EnumType
	{
		Enum8,
		Enum16,
		Enum32
	}

	public class EnumData : ValueField
	{
		[JsonProperty("type")]
		public EnumType Type { get; set; }

		[JsonProperty("value")]
		public int Value { get; set; }

		public EnumData(string name, uint offset, uint address, EnumType type, int value)
			: base(name, offset, address)
		{
			Type = type;
			Value = value;
		}
	}
}
