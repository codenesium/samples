using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineStepStepRequirementServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPipelineStepStepRequirementServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string Details { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[Required]
		[JsonProperty]
		public bool RequirementMet { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>39bf8e59ed64628d17ba0a1ff1330249</Hash>
</Codenesium>*/