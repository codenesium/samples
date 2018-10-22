using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public int PipelineStepId { get; private set; }

		[Required]
		[JsonProperty]
		public bool RequirementMet { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>ae8b8e25d8d8ee191e56d2123c5ddc4d</Hash>
</Codenesium>*/