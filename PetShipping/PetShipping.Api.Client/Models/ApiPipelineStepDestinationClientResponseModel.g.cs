using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiPipelineStepDestinationClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int destinationId,
			int pipelineStepId)
		{
			this.Id = id;
			this.DestinationId = destinationId;
			this.PipelineStepId = pipelineStepId;

			this.DestinationIdEntity = nameof(ApiResponse.Destinations);
			this.PipelineStepIdEntity = nameof(ApiResponse.PipelineSteps);
		}

		[JsonProperty]
		public int DestinationId { get; private set; }

		[JsonProperty]
		public string DestinationIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public string PipelineStepIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>1ac31e5f9c013bee9bbb6c5c5d57d3db</Hash>
</Codenesium>*/