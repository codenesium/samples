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
    <Hash>68122845154394bce232be45a3d340e3</Hash>
</Codenesium>*/