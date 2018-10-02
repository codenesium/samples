using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiClaspResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int nextChainId,
			int previousChainId)
		{
			this.Id = id;
			this.NextChainId = nextChainId;
			this.PreviousChainId = previousChainId;

			this.NextChainIdEntity = nameof(ApiResponse.Chains);
			this.PreviousChainIdEntity = nameof(ApiResponse.Chains);
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int NextChainId { get; private set; }

		[JsonProperty]
		public string NextChainIdEntity { get; set; }

		[JsonProperty]
		public int PreviousChainId { get; private set; }

		[JsonProperty]
		public string PreviousChainIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>6286857241798712c699a5dbd5549c90</Hash>
</Codenesium>*/