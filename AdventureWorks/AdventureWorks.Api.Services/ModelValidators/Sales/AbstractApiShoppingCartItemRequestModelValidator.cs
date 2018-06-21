using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiShoppingCartItemRequestModelValidator : AbstractValidator<ApiShoppingCartItemRequestModel>
        {
                private int existingRecordId;

                private IShoppingCartItemRepository shoppingCartItemRepository;

                public AbstractApiShoppingCartItemRequestModelValidator(IShoppingCartItemRepository shoppingCartItemRepository)
                {
                        this.shoppingCartItemRepository = shoppingCartItemRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiShoppingCartItemRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DateCreatedRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void ProductIDRules()
                {
                }

                public virtual void QuantityRules()
                {
                }

                public virtual void ShoppingCartIDRules()
                {
                        this.RuleFor(x => x.ShoppingCartID).NotNull();
                        this.RuleFor(x => x.ShoppingCartID).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>24b9475a4d6f262702524d6a794f5da4</Hash>
</Codenesium>*/