using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepStepRequirementResponseModel: AbstractApiResponseModel
	{
		public ApiPipelineStepStepRequirementResponseModel() : base()
		{}

		public void SetProperties(
			string details,
			int id,
			int pipelineStepId,
			bool requirementMet)
		{
			this.Details = details;
			this.Id = id.ToInt();
			this.RequirementMet = requirementMet.ToBoolean();

			this.PipelineStepId = new ReferenceEntity<int>(pipelineStepId,
			                                               nameof(ApiResponse.PipelineSteps));
		}

		public string Details { get; set; }
		public int Id { get; set; }
		public ReferenceEntity<int> PipelineStepId { get; set; }
		public bool RequirementMet { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDetailsValue { get; set; } = true;

		public bool ShouldSerializeDetails()
		{
			return this.ShouldSerializeDetailsValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepIdValue { get; set; } = true;

		public bool ShouldSerializePipelineStepId()
		{
			return this.ShouldSerializePipelineStepIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRequirementMetValue { get; set; } = true;

		public bool ShouldSerializeRequirementMet()
		{
			return this.ShouldSerializeRequirementMetValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDetailsValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializePipelineStepIdValue = false;
			this.ShouldSerializeRequirementMetValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>6236cf578e34384361bddc58a63051e2</Hash>
</Codenesium>*/