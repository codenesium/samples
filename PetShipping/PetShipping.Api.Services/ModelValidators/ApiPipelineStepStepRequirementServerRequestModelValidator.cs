using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepStepRequirementServerRequestModelValidator : AbstractApiPipelineStepStepRequirementServerRequestModelValidator, IApiPipelineStepStepRequirementServerRequestModelValidator
	{
		public ApiPipelineStepStepRequirementServerRequestModelValidator(IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository)
			: base(pipelineStepStepRequirementRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStepRequirementServerRequestModel model)
		{
			this.DetailRules();
			this.PipelineStepIdRules();
			this.RequirementMetRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStepRequirementServerRequestModel model)
		{
			this.DetailRules();
			this.PipelineStepIdRules();
			this.RequirementMetRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>06d8b30f8b748052be961c713aa89a1f</Hash>
</Codenesium>*/