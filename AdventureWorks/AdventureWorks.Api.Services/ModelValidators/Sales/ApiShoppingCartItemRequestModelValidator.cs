using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiShoppingCartItemRequestModelValidator: AbstractApiShoppingCartItemRequestModelValidator, IApiShoppingCartItemRequestModelValidator
        {
                public ApiShoppingCartItemRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiShoppingCartItemRequestModel model)
                {
                        this.DateCreatedRules();
                        this.ModifiedDateRules();
                        this.ProductIDRules();
                        this.QuantityRules();
                        this.ShoppingCartIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShoppingCartItemRequestModel model)
                {
                        this.DateCreatedRules();
                        this.ModifiedDateRules();
                        this.ProductIDRules();
                        this.QuantityRules();
                        this.ShoppingCartIDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>556cdb71ecce19b499907cecf19e5368</Hash>
</Codenesium>*/