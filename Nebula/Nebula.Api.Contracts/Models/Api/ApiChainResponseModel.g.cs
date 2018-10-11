using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiChainResponseModel : AbstractApiResponseModel
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
    <Hash>2e283bd5674ae72045c56b785a6186b1</Hash>
</Codenesium>*/