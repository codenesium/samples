using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiHandlerRequestModelValidator: AbstractApiHandlerRequestModelValidator, IApiHandlerRequestModelValidator
	{
		public ApiHandlerRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiHandlerRequestModel model)
		{
			this.CountryIdRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerRequestModel model)
		{
			this.CountryIdRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>98da23628ade09279f5854be3570f6d7</Hash>
</Codenesium>*/