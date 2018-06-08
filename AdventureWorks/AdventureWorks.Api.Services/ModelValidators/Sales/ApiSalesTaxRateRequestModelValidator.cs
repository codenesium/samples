using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesTaxRateRequestModelValidator: AbstractApiSalesTaxRateRequestModelValidator, IApiSalesTaxRateRequestModelValidator
        {
                public ApiSalesTaxRateRequestModelValidator()
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
    <Hash>19b046c1a62e029fec26546d010e9dfc</Hash>
</Codenesium>*/