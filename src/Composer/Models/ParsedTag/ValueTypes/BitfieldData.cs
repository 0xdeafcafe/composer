using Composer.Models.ParsedTag.ValueTypes.Abstracts;
using Newtonsoft.Json;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public enum BitfieldType
	{
		Bitfield8,
		Bitfield16,
		Bitfield32
	}

	public class BitfieldData : ValueField
	{
		[JsonProperty("type")]
		public BitfieldType Type;

		[JsonProperty("value")]
		public uint Value;

		public BitfieldData(string name, uint offset, uint address, BitfieldType type)
			: base(name, offset, address)
		{
			Type = type;
		}
	}
}
