using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCreditCardServerRequestModelValidator : AbstractApiCreditCardServerRequestModelValidator, IApiCreditCardServerRequestModelValidator
	{
		public ApiCreditCardServerRequestModelValidator(ICreditCardRepository creditCardRepository)
			: base(creditCardRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCreditCardServerRequestModel model)
		{
			this.CardNumberRules();
			this.CardTypeRules();
			this.ExpMonthRules();
			this.ExpYearRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardServerRequestModel model)
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
    <Hash>9b4f369d218eba63e13bb67398aec317</Hash>
</Codenesium>*/