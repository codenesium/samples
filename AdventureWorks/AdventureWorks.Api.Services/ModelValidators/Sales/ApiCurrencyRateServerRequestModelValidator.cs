using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCurrencyRateServerRequestModelValidator : AbstractApiCurrencyRateServerRequestModelValidator, IApiCurrencyRateServerRequestModelValidator
	{
		public ApiCurrencyRateServerRequestModelValidator(ICurrencyRateRepository currencyRateRepository)
			: base(currencyRateRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRateServerRequestModel model)
		{
			this.AverageRateRules();
			this.CurrencyRateDateRules();
			this.EndOfDayRateRules();
			this.FromCurrencyCodeRules();
			this.ModifiedDateRules();
			this.ToCurrencyCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCurrencyRateServerRequestModel model)
		{
			this.AverageRateRules();
			this.CurrencyRateDateRules();
			this.EndOfDayRateRules();
			this.FromCurrencyCodeRules();
			this.ModifiedDateRules();
			this.ToCurrencyCodeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>37d4e6680742d6c84a011c5930dcc199</Hash>
</Codenesium>*/