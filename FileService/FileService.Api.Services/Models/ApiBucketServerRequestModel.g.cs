using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Services
{
	public partial class ApiBucketServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiBucketServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			Guid externalId,
			string name)
		{
			this.ExternalId = externalId;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public Guid ExternalId { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>5dea2e6cde4b1c907acc77e4be6d7d12</Hash>
</Codenesium>*/