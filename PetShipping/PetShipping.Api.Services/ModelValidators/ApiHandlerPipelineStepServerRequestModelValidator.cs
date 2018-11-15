using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiHandlerPipelineStepServerRequestModelValidator : AbstractApiHandlerPipelineStepServerRequestModelValidator, IApiHandlerPipelineStepServerRequestModelValidator
	{
		public ApiHandlerPipelineStepServerRequestModelValidator(IHandlerPipelineStepRepository handlerPipelineStepRepository)
			: base(handlerPipelineStepRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiHandlerPipelineStepServerRequestModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerPipelineStepServerRequestModel model)
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
    <Hash>8fc1d4f6526de322cca1d23dac6eba8b</Hash>
</Codenesium>*/