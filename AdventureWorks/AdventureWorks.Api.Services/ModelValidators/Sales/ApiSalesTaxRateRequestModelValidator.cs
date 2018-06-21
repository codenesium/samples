using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesTaxRateRequestModelValidator : AbstractApiSalesTaxRateRequestModelValidator, IApiSalesTaxRateRequestModelValidator
        {
                public ApiSalesTaxRateRequestModelValidator(ISalesTaxRateRepository salesTaxRateRepository)
                        : base(salesTaxRateRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSalesTaxRateRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        this.StateProvinceIDRules();
                        this.TaxRateRules();
                        this.TaxTypeRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTaxRateRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        this.StateProvinceIDRules();
                        this.TaxRateRules();
                        this.TaxTypeRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>56ff8eb72008c8de682318069fc0ae86</Hash>
</Codenesium>*/