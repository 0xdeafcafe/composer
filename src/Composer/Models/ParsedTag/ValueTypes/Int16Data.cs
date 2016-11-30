using Composer.Models.ParsedTag.ValueTypes.Abstracts;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class Int16Data : NumberData<short>
	{
		public Int16Data(string name, uint offset, uint address, string type, short value)
			: base(name, offset, address, type, value)
		{ }
	}
}
