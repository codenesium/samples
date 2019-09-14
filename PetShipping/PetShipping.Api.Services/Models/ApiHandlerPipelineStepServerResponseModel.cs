using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiHandlerPipelineStepServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int handlerId,
			int pipelineStepId)
		{
			this.Id = id;
			this.HandlerId = handlerId;
			this.PipelineStepId = pipelineStepId;
		}

		[JsonProperty]
		public int HandlerId { get; private set; }

		[JsonProperty]
		public string HandlerIdEntity { get; private set; } = RouteConstants.Handlers;

		[JsonProperty]
		public ApiHandlerServerResponseModel HandlerIdNavigation { get; private set; }

		public void SetHandlerIdNavigation(ApiHandlerServerResponseModel value)
		{
			this.HandlerIdNavigation = value;
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
    <Hash>fc0d2d341e8546dc1744680f8866c7b0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/