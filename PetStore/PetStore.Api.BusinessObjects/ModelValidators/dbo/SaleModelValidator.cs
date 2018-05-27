using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class ApiSaleRequestModelValidator: AbstractApiSaleRequestModelValidator, IApiSaleRequestModelValidator
	{
		public ApiSaleRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model)
		{
			this.AmountRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PaymentTypeIdRules();
			this.PetIdRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model)
		{
			this.AmountRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PaymentTypeIdRules();
			this.PetIdRules();
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
    <Hash>72996b81bfced205fa26cee6f517b40a</Hash>
</Codenesium>*/