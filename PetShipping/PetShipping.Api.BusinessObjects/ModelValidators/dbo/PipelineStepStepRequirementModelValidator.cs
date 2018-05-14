using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiPipelineStepStepRequirementModelValidator: AbstractApiPipelineStepStepRequirementModelValidator, IApiPipelineStepStepRequirementModelValidator
	{
		public ApiPipelineStepStepRequirementModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStepRequirementModel model)
		{
			this.DetailsRules();
			this.PipelineStepIdRules();
			this.RequirementMetRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStepRequirementModel model)
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
    <Hash>6930a43cdd57961489d25bf9ef88fba5</Hash>
</Codenesium>*/