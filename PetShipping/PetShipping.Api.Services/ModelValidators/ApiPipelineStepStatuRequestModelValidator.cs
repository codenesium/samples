using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepStatuRequestModelValidator : AbstractApiPipelineStepStatuRequestModelValidator, IApiPipelineStepStatuRequestModelValidator
	{
		public ApiPipelineStepStatuRequestModelValidator(IPipelineStepStatuRepository pipelineStepStatuRepository)
			: base(pipelineStepStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStatuRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStatuRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>7fb3b4bf69489fe7a61e44724f148cdc</Hash>
</Codenesium>*/