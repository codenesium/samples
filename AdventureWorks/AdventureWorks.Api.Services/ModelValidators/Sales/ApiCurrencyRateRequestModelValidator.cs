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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>ec55a9ecea46a9e65f908bf33818dd08</Hash>
</Codenesium>*/