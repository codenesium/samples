using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiCurrencyRateRequestModelValidator : AbstractApiCurrencyRateRequestModelValidator, IApiCurrencyRateRequestModelValidator
        {
                public ApiCurrencyRateRequestModelValidator(ICurrencyRateRepository currencyRateRepository)
                        : base(currencyRateRepository)
                {
                }

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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>02d2d39d04d64c1f0717732eff86cccc</Hash>
</Codenesium>*/