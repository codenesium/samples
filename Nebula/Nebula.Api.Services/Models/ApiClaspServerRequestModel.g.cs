using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiClaspServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiClaspServerRequestModel()
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
    <Hash>f8afc36af185031be82ad88cef228221</Hash>
</Codenesium>*/