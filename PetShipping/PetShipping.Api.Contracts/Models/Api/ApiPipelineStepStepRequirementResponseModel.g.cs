using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepStepRequirementResponseModel : AbstractApiResponseModel
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

			this.PipelineStepIdEntity = nameof(ApiResponse.PipelineSteps);
		}

		[Required]
		[JsonProperty]
		public string Details { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public string PipelineStepIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public bool RequirementMet { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f708c454054b910ff2b17bffbfa532d4</Hash>
</Codenesium>*/