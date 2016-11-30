using Composer.Models.ParsedTag.ValueTypes.Abstracts;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class UInt16Data : NumberData<ushort>
	{
		public UInt16Data(string name, uint offset, uint address, string type, ushort value)
			: base(name, offset, address, type, value)
		{ }
	}
}
