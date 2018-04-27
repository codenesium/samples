using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class HandlerPipelineStepModelValidator: AbstractHandlerPipelineStepModelValidator, IHandlerPipelineStepModelValidator
	{
		public HandlerPipelineStepModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(HandlerPipelineStepModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, HandlerPipelineStepModel model)
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
    <Hash>900956131c920f0eb6b0a7715bc2cf2b</Hash>
</Codenesium>*/