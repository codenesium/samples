using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiCurrencyRateModelValidator: AbstractApiCurrencyRateModelValidator, IApiCurrencyRateModelValidator
	{
		public ApiCurrencyRateModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRateModel model)
		{
			this.AverageRateRules();
			this.CurrencyRateDateRules();
			this.EndOfDayRateRules();
			this.FromCurrencyCodeRules();
			this.ModifiedDateRules();
			this.ToCurrencyCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCurrencyRateModel model)
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
    <Hash>b58d6f542968caa3376e05194497da13</Hash>
</Codenesium>*/