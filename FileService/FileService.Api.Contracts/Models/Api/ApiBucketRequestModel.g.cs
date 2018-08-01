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

		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9b5776ede4289181bd945d7b33bff882</Hash>
</Codenesium>*/