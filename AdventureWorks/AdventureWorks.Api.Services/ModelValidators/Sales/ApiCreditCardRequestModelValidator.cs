using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCreditCardRequestModelValidator : AbstractApiCreditCardRequestModelValidator, IApiCreditCardRequestModelValidator
	{
		public ApiCreditCardRequestModelValidator(ICreditCardRepository creditCardRepository)
			: base(creditCardRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>fcc3457d5bc6856459d6290d4dcb538b</Hash>
</Codenesium>*/