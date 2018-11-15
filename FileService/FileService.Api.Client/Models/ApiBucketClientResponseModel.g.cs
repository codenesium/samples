using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Client
{
	public partial class ApiBucketClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			Guid externalId,
			string name)
		{
			this.Id = id;
			this.ExternalId = externalId;
			this.Name = name;
		}

		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5ee8432a92edc28798f89d4213f16dc3</Hash>
</Codenesium>*/