using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiPipelineStepStepRequirementClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPipelineStepStepRequirementClientRequestModel()
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

		[JsonProperty]
		public string Detail { get; private set; } = default(string);

		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public bool RequirementMet { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>0daf53fbe2966d0cf48e17ebdc48417b</Hash>
</Codenesium>*/