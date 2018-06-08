using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiCountryRegionCurrencyRequestModelValidator: AbstractApiCountryRegionCurrencyRequestModelValidator, IApiCountryRegionCurrencyRequestModelValidator
        {
                public ApiCountryRegionCurrencyRequestModelValidator()
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
    <Hash>240952fa837a4f2dcafcb20f5e320a88</Hash>
</Codenesium>*/