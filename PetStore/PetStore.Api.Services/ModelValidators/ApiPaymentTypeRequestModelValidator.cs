using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>7cf1cbfd0a110b1bd39ace7dfa427b77</Hash>
</Codenesium>*/