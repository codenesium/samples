using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiClaspRequestModel : AbstractApiRequestModel
	{
		public ApiClaspRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int nextChainId,
			int previousChainId)
		{
			this.NextChainId = nextChainId;
			this.PreviousChainId = previousChainId;
		}

		[Required]
		[JsonProperty]
		public int NextChainId { get; private set; }

		[Required]
		[JsonProperty]
		public int PreviousChainId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8f3a16bc547a62823bba5aa755053d5e</Hash>
</Codenesium>*/