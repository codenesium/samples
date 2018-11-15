using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Client
{
	public partial class ApiBucketClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiBucketClientRequestModel()
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
		public Guid ExternalId { get; private set; } = default(Guid);

		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>755bb38936f29d977f367256b223a561</Hash>
</Codenesium>*/