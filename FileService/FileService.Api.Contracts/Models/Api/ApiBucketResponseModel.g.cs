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

		public Guid ExternalId { get; private set; }
		public int Id { get; private set; }
		public string Name { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue { get; set; } = false;

		public bool ShouldSerializeExternalId()
		{
			return this.ShouldSerializeExternalIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = false;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = false;

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
    <Hash>94374d77a5f8492218b7ecefaa5dee9b</Hash>
</Codenesium>*/