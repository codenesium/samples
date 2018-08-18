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

			this.ChainStatusIdEntity = nameof(ApiResponse.ChainStatus);
			this.TeamIdEntity = nameof(ApiResponse.Teams);
		}

		[Required]
		[JsonProperty]
		public int ChainStatusId { get; private set; }

		[JsonProperty]
		public string ChainStatusIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int TeamId { get; private set; }

		[JsonProperty]
		public string TeamIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>ea3c3ae99ca288e887552944b1d4efb6</Hash>
</Codenesium>*/