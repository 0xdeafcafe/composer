using Composer.Models.ParsedTag.ValueTypes.Abstracts;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class Int8Data : NumberData<sbyte>
	{
		public Int8Data(string name, uint offset, uint address, string type, sbyte value)
			: base(name, offset, address, type, value)
		{ }
	}
}
