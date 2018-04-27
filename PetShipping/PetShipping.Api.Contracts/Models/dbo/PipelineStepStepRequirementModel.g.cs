using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class PipelineStepStepRequirementModel
	{
		public PipelineStepStepRequirementModel()
		{}

		public PipelineStepStepRequirementModel(
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
    <Hash>a6035497e907ffabb0e045dc0b7425e9</Hash>
</Codenesium>*/