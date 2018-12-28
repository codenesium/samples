using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineStepDestinationServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int destinationId,
			int pipelineStepId)
		{
			this.Id = id;
			this.DestinationId = destinationId;
			this.PipelineStepId = pipelineStepId;
		}

		[JsonProperty]
		public int DestinationId { get; private set; }

		[JsonProperty]
		public string DestinationIdEntity { get; private set; } = RouteConstants.Destinations;

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public string PipelineStepIdEntity { get; private set; } = RouteConstants.PipelineSteps;
	}
}

/*<Codenesium>
    <Hash>4698dff4c93311546465aadb3285926a</Hash>
</Codenesium>*/