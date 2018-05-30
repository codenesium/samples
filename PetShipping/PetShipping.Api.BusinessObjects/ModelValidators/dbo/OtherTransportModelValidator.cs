using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiOtherTransportRequestModelValidator: AbstractApiOtherTransportRequestModelValidator, IApiOtherTransportRequestModelValidator
	{
		public ApiOtherTransportRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportRequestModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportRequestModel model)
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
    <Hash>33e85b2bf032ad087c02a14c11a3b0f7</Hash>
</Codenesium>*/