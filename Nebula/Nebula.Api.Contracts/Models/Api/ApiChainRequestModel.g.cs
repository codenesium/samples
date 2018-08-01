using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiChainRequestModel : AbstractApiRequestModel
	{
		public ApiChainRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int chainStatusId,
			Guid externalId,
			string name,
			int teamId)
		{
			this.ChainStatusId = chainStatusId;
			this.ExternalId = externalId;
			this.Name = name;
			this.TeamId = teamId;
		}

		[JsonProperty]
		public int ChainStatusId { get; private set; }

		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int TeamId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>57bfc1d1ed776f6a815251cc3a1f93e8</Hash>
</Codenesium>*/