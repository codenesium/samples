using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCurrencyRateRequestModelValidator: AbstractApiCurrencyRateRequestModelValidator, IApiCurrencyRateRequestModelValidator
	{
		public ApiCurrencyRateRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRateRequestModel model)
		{
			this.AverageRateRules();
			this.CurrencyRateDateRules();
			this.EndOfDayRateRules();
			this.FromCurrencyCodeRules();
			this.ModifiedDateRules();
			this.ToCurrencyCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCurrencyRateRequestModel model)
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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>cc2ce1ff0cf0697a43c936dc36606bcc</Hash>
</Codenesium>*/