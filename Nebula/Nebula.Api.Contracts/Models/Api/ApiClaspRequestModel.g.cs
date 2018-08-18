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

		[JsonProperty]
		public int NextChainId { get; private set; }

		[JsonProperty]
		public int PreviousChainId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>439b5c97e533d8110cb97c127c873f29</Hash>
</Codenesium>*/