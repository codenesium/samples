using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiCurrencyRateRequestModelValidator: AbstractApiCurrencyRateRequestModelValidator, IApiCurrencyRateRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>44ac22d90da79843dfad8c0c382fa80a</Hash>
</Codenesium>*/