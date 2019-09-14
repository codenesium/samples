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
			string details,
			int pipelineStepId,
			bool requirementMet)
		{
			this.Details = details;
			this.PipelineStepId = pipelineStepId;
			this.RequirementMet = requirementMet;
		}

		[JsonProperty]
		public string Details { get; private set; } = default(string);

		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public bool RequirementMet { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>04ce14f8e0062b49835e2209c0c6e65d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/