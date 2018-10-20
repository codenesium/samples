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
		public string Detail { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PipelineStepId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public bool RequirementMet { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>8f9c8c7093f30f48e6592c50a5351f82</Hash>
</Codenesium>*/