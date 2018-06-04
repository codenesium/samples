using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepStepRequirementRequestModelValidator: AbstractApiPipelineStepStepRequirementRequestModelValidator, IApiPipelineStepStepRequirementRequestModelValidator
	{
		public ApiPipelineStepStepRequirementRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStepRequirementRequestModel model)
		{
			this.DetailsRules();
			this.PipelineStepIdRules();
			this.RequirementMetRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStepRequirementRequestModel model)
		{
			this.DetailsRules();
			this.PipelineStepIdRules();
			this.RequirementMetRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c83530698dc2df342d6837e12772ffea</Hash>
</Codenesium>*/