using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesTaxRateRequestModelValidator: AbstractApiSalesTaxRateRequestModelValidator, IApiSalesTaxRateRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>f55d8256ae21b5099c01ac381708fd15</Hash>
</Codenesium>*/