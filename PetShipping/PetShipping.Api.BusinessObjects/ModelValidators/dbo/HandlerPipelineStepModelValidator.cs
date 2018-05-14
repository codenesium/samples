using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiHandlerPipelineStepModelValidator: AbstractApiHandlerPipelineStepModelValidator, IApiHandlerPipelineStepModelValidator
	{
		public ApiHandlerPipelineStepModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiHandlerPipelineStepModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerPipelineStepModel model)
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
    <Hash>2977e496bafe5428cd36275908c91185</Hash>
</Codenesium>*/