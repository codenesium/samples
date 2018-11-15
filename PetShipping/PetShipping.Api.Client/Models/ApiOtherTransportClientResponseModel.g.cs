using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiOtherTransportClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int handlerId,
			int pipelineStepId)
		{
			this.Id = id;
			this.HandlerId = handlerId;
			this.PipelineStepId = pipelineStepId;

			this.HandlerIdEntity = nameof(ApiResponse.Handlers);
			this.PipelineStepIdEntity = nameof(ApiResponse.PipelineSteps);
		}

		[JsonProperty]
		public int HandlerId { get; private set; }

		[JsonProperty]
		public string HandlerIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public string PipelineStepIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>39dad33c17a1fd8bf3857ae013150749</Hash>
</Codenesium>*/