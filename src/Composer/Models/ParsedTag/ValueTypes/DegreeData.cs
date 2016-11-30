using Composer.Models.ParsedTag.ValueTypes.Abstracts;
using Newtonsoft.Json;

namespace Composer.Models.ParsedTag.ValueTypes
{
	public class DegreeData : ValueField
	{
		[JsonProperty("radian")]
		public float Radian;

		public DegreeData(string name, uint offset, uint address, float radian)
			: base(name, offset, address)
		{
			Radian = radian;
		}
	}
}
