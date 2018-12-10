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
		public string NextChainIdEntity { get; set; }

		[JsonProperty]
		public int PreviousChainId { get; private set; }

		[JsonProperty]
		public string PreviousChainIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>9cdcfc57aefc5a1fb995973cab90c152</Hash>
</Codenesium>*/