using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiChainClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiChainClientRequestModel()
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
		public Guid ExternalId { get; private set; } = default(Guid);

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public int TeamId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>45eddd2d9b2a17ae24bf2476ef16e79b</Hash>
</Codenesium>*/