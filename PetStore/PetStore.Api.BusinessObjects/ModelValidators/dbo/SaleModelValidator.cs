using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class ApiSaleModelValidator: AbstractApiSaleModelValidator, IApiSaleModelValidator
	{
		public ApiSaleModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleModel model)
		{
			this.AmountRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PaymentTypeIdRules();
			this.PetIdRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleModel model)
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
    <Hash>dd7fbda87591b9581efb1332603ed422</Hash>
</Codenesium>*/