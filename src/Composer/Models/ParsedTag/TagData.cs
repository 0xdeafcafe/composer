using System.Collections.Generic;
using Composer.Models.ParsedTag.ValueTypes.Abstracts;
using Newtonsoft.Json;

namespace Composer.Models.ParsedTag
{
	public class TagData
	{
		[JsonProperty("revisions")]
		public IList<TagRevision> Revisions { get; set; } = new List<TagRevision>();

		[JsonProperty("fields")]
		public IList<DataField> Fields { get; set; } = new List<DataField>();
	}
}
