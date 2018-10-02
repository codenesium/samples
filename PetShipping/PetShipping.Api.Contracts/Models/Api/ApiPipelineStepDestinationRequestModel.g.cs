using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepDestinationRequestModel : AbstractApiRequestModel
	{
		public ApiPipelineStepDestinationRequestModel()
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

		[Required]
		[JsonProperty]
		public int DestinationId { get; private set; }

		[Required]
		[JsonProperty]
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6365bd4a24ac0cd103babf7dbf5147fc</Hash>
</Codenesium>*/