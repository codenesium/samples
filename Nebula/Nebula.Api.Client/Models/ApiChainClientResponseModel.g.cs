using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiChainClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int chainStatusId,
			Guid externalId,
			string name,
			int teamId)
		{
			this.Id = id;
			this.ChainStatusId = chainStatusId;
			this.ExternalId = externalId;
			this.Name = name;
			this.TeamId = teamId;

			this.ChainStatusIdEntity = nameof(ApiResponse.ChainStatuses);

			this.TeamIdEntity = nameof(ApiResponse.Teams);
		}

		[JsonProperty]
		public ApiChainStatusClientResponseModel ChainStatusIdNavigation { get; private set; }

		public void SetChainStatusIdNavigation(ApiChainStatusClientResponseModel value)
		{
			this.ChainStatusIdNavigation = value;
		}

		[JsonProperty]
		public ApiTeamClientResponseModel TeamIdNavigation { get; private set; }

		public void SetTeamIdNavigation(ApiTeamClientResponseModel value)
		{
			this.TeamIdNavigation = value;
		}

		[JsonProperty]
		public int ChainStatusId { get; private set; }

		[JsonProperty]
		public string ChainStatusIdEntity { get; set; }

		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int TeamId { get; private set; }

		[JsonProperty]
		public string TeamIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>11e5accf98c92831f5fa82e8eec19d1f</Hash>
</Codenesium>*/