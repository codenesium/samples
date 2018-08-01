using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiHandlerPipelineStepRequestModelValidator : AbstractApiHandlerPipelineStepRequestModelValidator, IApiHandlerPipelineStepRequestModelValidator
	{
		public ApiHandlerPipelineStepRequestModelValidator(IHandlerPipelineStepRepository handlerPipelineStepRepository)
			: base(handlerPipelineStepRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>d6e5f8471592757589b707fe73daf437</Hash>
</Codenesium>*/