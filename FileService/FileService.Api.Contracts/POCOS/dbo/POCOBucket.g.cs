using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FileServiceNS.Api.Contracts
{
	public partial class POCOBucket
	{
		public POCOBucket()
		{}

		public POCOBucket(
			int id,
			string name,
			Guid externalId)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.ExternalId = externalId.ToGuid();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public Guid ExternalId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue { get; set; } = true;

		public bool ShouldSerializeExternalId()
		{
			return this.ShouldSerializeExternalIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeExternalIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>a008f5ebd1100da351b92ed7fde94c9e</Hash>
</Codenesium>*/