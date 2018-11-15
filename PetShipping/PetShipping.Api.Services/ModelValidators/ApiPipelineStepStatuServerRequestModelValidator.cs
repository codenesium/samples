using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepStatuServerRequestModelValidator : AbstractApiPipelineStepStatuServerRequestModelValidator, IApiPipelineStepStatuServerRequestModelValidator
	{
		public ApiPipelineStepStatuServerRequestModelValidator(IPipelineStepStatuRepository pipelineStepStatuRepository)
			: base(pipelineStepStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStatuServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStatuServerRequestModel model)
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
    <Hash>b3b2bee29d2018027be5974102b36c40</Hash>
</Codenesium>*/