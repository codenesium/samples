using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiCreditCardModelValidator: AbstractApiCreditCardModelValidator, IApiCreditCardModelValidator
	{
		public ApiCreditCardModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCreditCardModel model)
		{
			this.CardNumberRules();
			this.CardTypeRules();
			this.ExpMonthRules();
			this.ExpYearRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardModel model)
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
    <Hash>c3f1d2a4d4474ddf8518ffe6cbd5941a</Hash>
</Codenesium>*/