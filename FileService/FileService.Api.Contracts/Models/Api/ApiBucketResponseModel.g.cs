using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
	public partial class ApiBucketResponseModel : AbstractApiResponseModel
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
    <Hash>8113f0ae8190bf3fc2e854e9542ad50e</Hash>
</Codenesium>*/