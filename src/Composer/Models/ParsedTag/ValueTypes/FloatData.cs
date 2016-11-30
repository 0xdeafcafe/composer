using Composer.Models.ParsedTag.ValueTypes.Abstracts;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class FloatData : NumberData<float>
	{
		public FloatData(string name, uint offset, uint address, string type, float value)
			: base(name, offset, address, type, value)
		{ }
	}
}
