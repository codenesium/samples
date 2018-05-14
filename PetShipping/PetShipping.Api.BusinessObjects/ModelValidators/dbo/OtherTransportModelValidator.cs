using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiOtherTransportModelValidator: AbstractApiOtherTransportModelValidator, IApiOtherTransportModelValidator
	{
		public ApiOtherTransportModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportModel model)
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
    <Hash>5ab53172ea8b053b72aa415b2dc92fce</Hash>
</Codenesium>*/