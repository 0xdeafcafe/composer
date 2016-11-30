using Composer.Models.ParsedTag.ValueTypes.Abstracts;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class Int32Data : NumberData<int>
	{

		public Int32Data(string name, uint offset, uint address, string type, int value)
			: base(name, offset, address, type, value)
		{ }
	}
}
