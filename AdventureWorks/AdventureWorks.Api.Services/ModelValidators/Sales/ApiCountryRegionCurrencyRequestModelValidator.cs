using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiCountryRegionCurrencyRequestModelValidator: AbstractApiCountryRegionCurrencyRequestModelValidator, IApiCountryRegionCurrencyRequestModelValidator
        {
                public ApiCountryRegionCurrencyRequestModelValidator(ICountryRegionCurrencyRepository countryRegionCurrencyRepository)
                        : base(countryRegionCurrencyRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionCurrencyRequestModel model)
                {
                        this.CurrencyCodeRules();
                        this.ModifiedDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionCurrencyRequestModel model)
                {
                        this.CurrencyCodeRules();
                        this.ModifiedDateRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>67c81e7f2ae6a990770269aea8306905</Hash>
</Codenesium>*/