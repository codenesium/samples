using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiClaspServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int nextChainId,
			int previousChainId)
		{
			this.Id = id;
			this.NextChainId = nextChainId;
			this.PreviousChainId = previousChainId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int NextChainId { get; private set; }

		[JsonProperty]
		public string NextChainIdEntity { get; private set; } = RouteConstants.Chains;

		[JsonProperty]
		public ApiChainServerResponseModel NextChainIdNavigation { get; private set; }

		public void SetNextChainIdNavigation(ApiChainServerResponseModel value)
		{
			this.NextChainIdNavigation = value;
		}

		[JsonProperty]
		public int PreviousChainId { get; private set; }

		[JsonProperty]
		public string PreviousChainIdEntity { get; private set; } = RouteConstants.Chains;

		[JsonProperty]
		public ApiChainServerResponseModel PreviousChainIdNavigation { get; private set; }

		public void SetPreviousChainIdNavigation(ApiChainServerResponseModel value)
		{
			this.PreviousChainIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>d903e6d8b8bcadc9b09be4493eb8cdb0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/