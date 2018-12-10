using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiClaspClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>f580a5844e195382f7de6828fe6bafd9</Hash>
</Codenesium>*/