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
		public ApiDestinationClientResponseModel DestinationIdNavigation { get; private set; }

		public void SetDestinationIdNavigation(ApiDestinationClientResponseModel value)
		{
			this.DestinationIdNavigation = value;
		}

		[JsonProperty]
		public ApiPipelineStepClientResponseModel PipelineStepIdNavigation { get; private set; }

		public void SetPipelineStepIdNavigation(ApiPipelineStepClientResponseModel value)
		{
			this.PipelineStepIdNavigation = value;
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
    <Hash>bd2c8a8db3e86a350ed849a3f413f0ae</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/