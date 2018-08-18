using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiApiKeyResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string apiKeyHashed,
			DateTimeOffset created,
			string jSON,
			string userId)
		{
			this.Id = id;
			this.ApiKeyHashed = apiKeyHashed;
			this.Created = created;
			this.JSON = jSON;
			this.UserId = userId;
		}

		[Required]
		[JsonProperty]
		public string ApiKeyHashed { get; private set; }

		[Required]
		[JsonProperty]
		public DateTimeOffset Created { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>eb5a4f95567d09ad2458a6e318ada76f</Hash>
</Codenesium>*/