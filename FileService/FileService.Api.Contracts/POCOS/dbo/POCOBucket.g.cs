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
			Guid externalId,
			int id,
			string name)
		{
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.Name = name;
		}

		public Guid ExternalId { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue { get; set; } = true;

		public bool ShouldSerializeExternalId()
		{
			return this.ShouldSerializeExternalIdValue;
		}

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

		public void DisableAllFields()
		{
			this.ShouldSerializeExternalIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>fb5cdd9c0788aeec991420c9a5019de0</Hash>
</Codenesium>*/