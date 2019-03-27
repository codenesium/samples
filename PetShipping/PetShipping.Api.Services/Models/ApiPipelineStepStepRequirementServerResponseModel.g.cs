using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineStepStepRequirementServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string details,
			int pipelineStepId,
			bool requirementMet)
		{
			this.Id = id;
			this.Details = details;
			this.PipelineStepId = pipelineStepId;
			this.RequirementMet = requirementMet;
		}

		[JsonProperty]
		public string Details { get; private set; }

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

		[JsonProperty]
		public bool RequirementMet { get; private set; }
	}
}

/*<Codenesium>
    <Hash>edfe10181f42995de8ffbdf3ca04e068</Hash>
</Codenesium>*/