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
		public string PipelineStepIdEntity { get; set; }

		[JsonProperty]
		public bool RequirementMet { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3dcaba2cc9b2e17824b5142c9216a491</Hash>
</Codenesium>*/