using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FileServiceNS.Api.Contracts
{
	public partial class POCOBucket
	{
		public POCOBucket()
		{}

		public POCOBucket(int id,
		                  string name,
		                  Guid externalId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.ExternalId = externalId;
		}

		public int Id {get; set;}
		public string Name {get; set;}
		public Guid ExternalId {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue {get; set;} = true;

		public bool ShouldSerializeExternalId()
		{
			return ShouldSerializeExternalIdValue;
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
    <Hash>c83b41c03260486995601678fdd482fd</Hash>
</Codenesium>*/