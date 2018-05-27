using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class ApiPaymentTypeRequestModelValidator: AbstractApiPaymentTypeRequestModelValidator, IApiPaymentTypeRequestModelValidator
	{
		public ApiPaymentTypeRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPaymentTypeRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPaymentTypeRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>3dbfa8ad9ad5c1c3c1668fb4e3738d04</Hash>
</Codenesium>*/