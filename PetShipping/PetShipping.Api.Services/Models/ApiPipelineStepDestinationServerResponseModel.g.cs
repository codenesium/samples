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
		public ApiDestinationServerResponseModel DestinationIdNavigation { get; private set; }

		public void SetDestinationIdNavigation(ApiDestinationServerResponseModel value)
		{
			this.DestinationIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public string PipelineStepIdEntity { get; private set; } = RouteConstants.PipelineSteps;

		[JsonProperty]
		public ApiPipelineStepServerResponseModel PipelineStepIdNavigation { get; private set; }

		public void SetPipelineStepIdNavigation(ApiPipelineStepServerResponseModel value)
		{
			this.PipelineStepIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>141da7590c7d971e88f2e8f25b2fd47f</Hash>
</Codenesium>*/