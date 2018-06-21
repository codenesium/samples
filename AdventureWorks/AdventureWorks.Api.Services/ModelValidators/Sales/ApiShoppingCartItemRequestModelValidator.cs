using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiShoppingCartItemRequestModelValidator : AbstractApiShoppingCartItemRequestModelValidator, IApiShoppingCartItemRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>b3e9b3e5f3f541fb166ca9750f0ac24a</Hash>
</Codenesium>*/