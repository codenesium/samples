using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepStepRequirementModel
	{
		public ApiPipelineStepStepRequirementModel()
		{}

		public ApiPipelineStepStepRequirementModel(
			string details,
			int pipelineStepId,
			bool requirementMet)
		{
			this.Details = details.ToString();
			this.PipelineStepId = pipelineStepId.ToInt();
			this.RequirementMet = requirementMet.ToBoolean();
		}

		private string details;

		[Required]
		public string Details
		{
			get
			{
				return this.details;
			}

			set
			{
				this.details = value;
			}
		}

		private int pipelineStepId;

		[Required]
		public int PipelineStepId
		{
			get
			{
				return this.pipelineStepId;
			}

			set
			{
				this.pipelineStepId = value;
			}
		}

		private bool requirementMet;

		[Required]
		public bool RequirementMet
		{
			get
			{
				return this.requirementMet;
			}

			set
			{
				this.requirementMet = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>a0ca5005eaff6d6fad005e8c400aa604</Hash>
</Codenesium>*/