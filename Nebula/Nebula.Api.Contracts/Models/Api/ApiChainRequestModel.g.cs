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

		[Required]
		[JsonProperty]
		public int ChainStatusId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public Guid ExternalId { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int TeamId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>472e3104f935dadf4a7420a19b3a4304</Hash>
</Codenesium>*/