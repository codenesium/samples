using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
	public partial class ApiBucketRequestModel : AbstractApiRequestModel
	{
		public ApiBucketRequestModel()
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
    <Hash>e56865b0f45f1a5cd6b372eabd4026c2</Hash>
</Codenesium>*/