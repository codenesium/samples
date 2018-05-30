using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>5b3fbac68001d0b1375c9abb9d532917</Hash>
</Codenesium>*/