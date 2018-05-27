using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiCreditCardRequestModelValidator: AbstractApiCreditCardRequestModelValidator, IApiCreditCardRequestModelValidator
	{
		public ApiCreditCardRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCreditCardRequestModel model)
		{
			this.CardNumberRules();
			this.CardTypeRules();
			this.ExpMonthRules();
			this.ExpYearRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardRequestModel model)
		{
			this.CardNumberRules();
			this.CardTypeRules();
			this.ExpMonthRules();
			this.ExpYearRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>38d7a68c95ba24ed0e6289e0426a98e3</Hash>
</Codenesium>*/