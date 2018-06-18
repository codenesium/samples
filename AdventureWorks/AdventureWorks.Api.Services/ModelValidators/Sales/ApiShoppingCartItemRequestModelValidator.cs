using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiShoppingCartItemRequestModelValidator: AbstractApiShoppingCartItemRequestModelValidator, IApiShoppingCartItemRequestModelValidator
        {
                public ApiShoppingCartItemRequestModelValidator(IShoppingCartItemRepository shoppingCartItemRepository)
                        : base(shoppingCartItemRepository)
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
    <Hash>fd612beed9a913a96f2cad818417c5f7</Hash>
</Codenesium>*/