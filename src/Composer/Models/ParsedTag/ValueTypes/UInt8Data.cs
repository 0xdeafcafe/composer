using Composer.Models.ParsedTag.ValueTypes.Abstracts;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class UInt8Data : NumberData<byte>
	{
		public UInt8Data(string name, uint offset, uint address, string type, byte value)
			: base(name, offset, address, type, value)
		{ }
	}
}
