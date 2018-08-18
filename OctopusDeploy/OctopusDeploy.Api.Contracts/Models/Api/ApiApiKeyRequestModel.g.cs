using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiApiKeyRequestModel : AbstractApiRequestModel
	{
		public ApiApiKeyRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string apiKeyHashed,
			DateTimeOffset created,
			string jSON,
			string userId)
		{
			this.ApiKeyHashed = apiKeyHashed;
			this.Created = created;
			this.JSON = jSON;
			this.UserId = userId;
		}

		[JsonProperty]
		public string ApiKeyHashed { get; private set; }

		[JsonProperty]
		public DateTimeOffset Created { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>17f024ef47f6134b683de93fa1a120a6</Hash>
</Codenesium>*/