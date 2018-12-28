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
			string detail,
			int pipelineStepId,
			bool requirementMet)
		{
			this.Id = id;
			this.Detail = detail;
			this.PipelineStepId = pipelineStepId;
			this.RequirementMet = requirementMet;
		}

		[JsonProperty]
		public string Detail { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public string PipelineStepIdEntity { get; private set; } = RouteConstants.PipelineSteps;

		[JsonProperty]
		public bool RequirementMet { get; private set; }
	}
}

/*<Codenesium>
    <Hash>aea38006fd6f2163210a7adc903c2413</Hash>
</Codenesium>*/