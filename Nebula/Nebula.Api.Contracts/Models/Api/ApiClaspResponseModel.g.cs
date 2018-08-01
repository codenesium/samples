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

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public int NextChainId { get; private set; }

		[JsonProperty]
		public string NextChainIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public int PreviousChainId { get; private set; }

		[JsonProperty]
		public string PreviousChainIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>32bae065d8d55f1245381980f04db729</Hash>
</Codenesium>*/