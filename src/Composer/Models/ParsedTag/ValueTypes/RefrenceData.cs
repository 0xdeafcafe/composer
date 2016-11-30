namespace Composer.Models.ParsedTag.ValueTypes
{
	public class DataRef : RawData
	{
		public DataRef(string name, uint offset, string format, uint address, uint dataAddress, string value, int length)
			: base(name, offset, format, address, value, length)
		{
			DataAddress = dataAddress;
		}
	}
}
