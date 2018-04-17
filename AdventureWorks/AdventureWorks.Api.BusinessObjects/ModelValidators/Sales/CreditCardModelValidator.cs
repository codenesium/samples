using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class CreditCardModelValidator: AbstractCreditCardModelValidator, ICreditCardModelValidator
	{
		public CreditCardModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(CreditCardModel model)
		{
			this.CardTypeRules();
			this.CardNumberRules();
			this.ExpMonthRules();
			this.ExpYearRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, CreditCardModel model)
		{
			this.CardTypeRules();
			this.CardNumberRules();
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
    <Hash>380bed728ea823c4ff296d6d598d7f73</Hash>
</Codenesium>*/