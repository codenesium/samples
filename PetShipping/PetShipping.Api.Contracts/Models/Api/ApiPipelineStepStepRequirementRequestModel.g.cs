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
			string details,
			int pipelineStepId,
			bool requirementMet)
		{
			this.Details = details;
			this.PipelineStepId = pipelineStepId;
			this.RequirementMet = requirementMet;
		}

		[JsonProperty]
		public string Details { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public bool RequirementMet { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8ab7c8791d471c023079446d465145a6</Hash>
</Codenesium>*/