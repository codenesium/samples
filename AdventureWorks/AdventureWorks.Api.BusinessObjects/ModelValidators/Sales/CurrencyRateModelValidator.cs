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
			this.AverageRateRules();
			this.CurrencyRateDateRules();
			this.EndOfDayRateRules();
			this.FromCurrencyCodeRules();
			this.ModifiedDateRules();
			this.ToCurrencyCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, CurrencyRateModel model)
		{
			this.AverageRateRules();
			this.CurrencyRateDateRules();
			this.EndOfDayRateRules();
			this.FromCurrencyCodeRules();
			this.ModifiedDateRules();
			this.ToCurrencyCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>251fb2fb743d5fdd3c466d60165412fa</Hash>
</Codenesium>*/