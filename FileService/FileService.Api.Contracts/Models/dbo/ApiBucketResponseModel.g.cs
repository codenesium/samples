using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FileServiceNS.Api.Contracts
{
	public partial class ApiBucketResponseModel: AbstractApiResponseModel
	{
		public ApiBucketResponseModel() : base()
		{}

		public void SetProperties(
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
    <Hash>af3c840d7dd8be0a1bd50bea7a76f892</Hash>
</Codenesium>*/