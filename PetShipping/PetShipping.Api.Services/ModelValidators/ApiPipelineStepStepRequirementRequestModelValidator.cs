using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepStepRequirementRequestModelValidator : AbstractApiPipelineStepStepRequirementRequestModelValidator, IApiPipelineStepStepRequirementRequestModelValidator
	{
		public ApiPipelineStepStepRequirementRequestModelValidator(IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository)
			: base(pipelineStepStepRequirementRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>cddfbf496f988f888ebf4e59ff9023b1</Hash>
</Codenesium>*/