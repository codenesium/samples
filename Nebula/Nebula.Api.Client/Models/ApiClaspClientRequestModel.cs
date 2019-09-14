using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiClaspClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiClaspClientRequestModel()
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
    <Hash>cb08030f5f3711c14234d0d85656d75e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/