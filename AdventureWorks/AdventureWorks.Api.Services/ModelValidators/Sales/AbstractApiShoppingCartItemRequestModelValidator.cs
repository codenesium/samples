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
    <Hash>1f6137ad78c56de9958287811224d993</Hash>
</Codenesium>*/