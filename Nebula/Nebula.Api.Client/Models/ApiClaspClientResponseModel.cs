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
		public ApiChainClientResponseModel NextChainIdNavigation { get; private set; }

		public void SetNextChainIdNavigation(ApiChainClientResponseModel value)
		{
			this.NextChainIdNavigation = value;
		}

		[JsonProperty]
		public ApiChainClientResponseModel PreviousChainIdNavigation { get; private set; }

		public void SetPreviousChainIdNavigation(ApiChainClientResponseModel value)
		{
			this.PreviousChainIdNavigation = value;
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
    <Hash>b40346b7f11d0c3cb9e93f7311652c93</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/