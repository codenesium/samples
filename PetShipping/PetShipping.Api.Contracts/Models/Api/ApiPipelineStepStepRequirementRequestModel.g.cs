using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepStepRequirementRequestModel : AbstractApiRequestModel
	{
		public ApiPipelineStepStepRequirementRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string detail,
			int pipelineStepId,
			bool requirementMet)
		{
			this.Detail = detail;
			this.PipelineStepId = pipelineStepId;
			this.RequirementMet = requirementMet;
		}

		[Required]
		[JsonProperty]
		public string Detail { get; private set; }

		[Required]
		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[Required]
		[JsonProperty]
		public bool RequirementMet { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3cfa5e3093843d1cfa9d8ec244ee6d7b</Hash>
</Codenesium>*/