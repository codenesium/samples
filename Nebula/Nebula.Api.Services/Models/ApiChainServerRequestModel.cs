using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiChainServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiChainServerRequestModel()
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
		public int ChainStatusId { get; private set; }

		[Required]
		[JsonProperty]
		public Guid ExternalId { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int TeamId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6d1ccc2c70dc5cc98ae1f945de2cc0bd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/