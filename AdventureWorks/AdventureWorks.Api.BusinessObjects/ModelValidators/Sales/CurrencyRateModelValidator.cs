using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class CurrencyRateModelValidator: AbstractCurrencyRateModelValidator, ICurrencyRateModelValidator
	{
		public CurrencyRateModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(CurrencyRateModel model)
		{
			this.CurrencyRateDateRules();
			this.FromCurrencyCodeRules();
			this.ToCurrencyCodeRules();
			this.AverageRateRules();
			this.EndOfDayRateRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, CurrencyRateModel model)
		{
			this.CurrencyRateDateRules();
			this.FromCurrencyCodeRules();
			this.ToCurrencyCodeRules();
			this.AverageRateRules();
			this.EndOfDayRateRules();
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
    <Hash>6bd9ff5dede5ab4366d519ecb1a4ba52</Hash>
</Codenesium>*/