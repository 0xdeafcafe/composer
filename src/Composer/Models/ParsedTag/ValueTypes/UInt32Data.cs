using Composer.Models.ParsedTag.ValueTypes.Abstracts;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class UInt32Data : NumberData<uint>
	{
		public UInt32Data(string name, uint offset, uint address, string type, uint value)
			: base(name, offset, address, type, value)
		{ }
	}
}
