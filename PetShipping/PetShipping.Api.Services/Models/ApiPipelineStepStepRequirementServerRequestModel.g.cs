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
    <Hash>1507dac8c9ee0ee7674654365ac47d11</Hash>
</Codenesium>*/