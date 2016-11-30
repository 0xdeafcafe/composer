using Newtonsoft.Json;

namespace Composer.Models.ParsedTag.ValueTypes.Abstracts
{
	public abstract class NumberData<T> : ValueField
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("value")]
		public T Value { get; set; }

		public NumberData(string name, uint offset, uint address, string type, T value)
			: base(name, offset, address)
		{
			Type = type;
			Value = value;
		}
	}
}
