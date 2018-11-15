using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiOtherTransportClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiOtherTransportClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int handlerId,
			int pipelineStepId)
		{
			this.HandlerId = handlerId;
			this.PipelineStepId = pipelineStepId;
		}

		[JsonProperty]
		public int HandlerId { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0f285f249f939da2594a370bc3891803</Hash>
</Codenesium>*/