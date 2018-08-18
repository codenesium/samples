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
    <Hash>441550c5e97cbc6bd3e89b09746e87c2</Hash>
</Codenesium>*/