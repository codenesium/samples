using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiOtherTransportRequestModel : AbstractApiRequestModel
	{
		public ApiOtherTransportRequestModel()
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
    <Hash>777b1b0bb6661531f21f9862bd8cedee</Hash>
</Codenesium>*/