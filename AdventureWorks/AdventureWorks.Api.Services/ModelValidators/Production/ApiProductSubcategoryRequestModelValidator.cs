using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductSubcategoryRequestModelValidator: AbstractApiProductSubcategoryRequestModelValidator, IApiProductSubcategoryRequestModelValidator
        {
                public ApiProductSubcategoryRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductSubcategoryRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.ProductCategoryIDRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductSubcategoryRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.ProductCategoryIDRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>4f94d8c7625ab63cdf51c3e226bbbfe5</Hash>
</Codenesium>*/