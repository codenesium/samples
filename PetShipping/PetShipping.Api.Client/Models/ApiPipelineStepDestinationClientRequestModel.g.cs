using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiPipelineStepDestinationClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPipelineStepDestinationClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int destinationId,
			int pipelineStepId)
		{
			this.DestinationId = destinationId;
			this.PipelineStepId = pipelineStepId;
		}

		[JsonProperty]
		public int DestinationId { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>96c091047d7c156f04e4e45957a38a44</Hash>
</Codenesium>*/