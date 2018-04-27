using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class PipelineStepStepRequirementModelValidator: AbstractPipelineStepStepRequirementModelValidator, IPipelineStepStepRequirementModelValidator
	{
		public PipelineStepStepRequirementModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PipelineStepStepRequirementModel model)
		{
			this.DetailsRules();
			this.PipelineStepIdRules();
			this.RequirementMetRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PipelineStepStepRequirementModel model)
		{
			this.DetailsRules();
			this.PipelineStepIdRules();
			this.RequirementMetRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>9aafb832938816b06c65c26770d2f924</Hash>
</Codenesium>*/