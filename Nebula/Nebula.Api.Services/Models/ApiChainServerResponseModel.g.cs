using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiChainServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public int ChainStatusId { get; private set; }

		[JsonProperty]
		public string ChainStatusIdEntity { get; private set; } = RouteConstants.ChainStatuses;

		[JsonProperty]
		public ApiChainStatusServerResponseModel ChainStatusIdNavigation { get; private set; }

		public void SetChainStatusIdNavigation(ApiChainStatusServerResponseModel value)
		{
			this.ChainStatusIdNavigation = value;
		}

		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int TeamId { get; private set; }

		[JsonProperty]
		public string TeamIdEntity { get; private set; } = RouteConstants.Teams;

		[JsonProperty]
		public ApiTeamServerResponseModel TeamIdNavigation { get; private set; }

		public void SetTeamIdNavigation(ApiTeamServerResponseModel value)
		{
			this.TeamIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>39ace339e6db87174cfb057eb40182ed</Hash>
</Codenesium>*/