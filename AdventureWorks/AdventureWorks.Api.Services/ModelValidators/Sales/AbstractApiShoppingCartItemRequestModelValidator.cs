using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services

{
        public abstract class AbstractApiShoppingCartItemRequestModelValidator: AbstractValidator<ApiShoppingCartItemRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiShoppingCartItemRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiShoppingCartItemRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DateCreatedRules()
                {
                        this.RuleFor(x => x.DateCreated).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void ProductIDRules()
                {
                        this.RuleFor(x => x.ProductID).NotNull();
                }

                public virtual void QuantityRules()
                {
                        this.RuleFor(x => x.Quantity).NotNull();
                }

                public virtual void ShoppingCartIDRules()
                {
                        this.RuleFor(x => x.ShoppingCartID).NotNull();
                        this.RuleFor(x => x.ShoppingCartID).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>acbc2b62763db7ad2fe2857dadbff63e</Hash>
</Codenesium>*/