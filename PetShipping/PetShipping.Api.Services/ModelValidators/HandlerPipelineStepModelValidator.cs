using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class ApiHandlerPipelineStepRequestModelValidator: AbstractApiHandlerPipelineStepRequestModelValidator, IApiHandlerPipelineStepRequestModelValidator
	{
		public ApiHandlerPipelineStepRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiHandlerPipelineStepRequestModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerPipelineStepRequestModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>a4d4f5c1d9dd12411d03f16fe307bd2b</Hash>
</Codenesium>*/