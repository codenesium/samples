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
        public abstract class AbstractApiProductInventoryRequestModelValidator: AbstractValidator<ApiProductInventoryRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiProductInventoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductInventoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void BinRules()
                {
                        this.RuleFor(x => x.Bin).NotNull();
                }

                public virtual void LocationIDRules()
                {
                        this.RuleFor(x => x.LocationID).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void QuantityRules()
                {
                        this.RuleFor(x => x.Quantity).NotNull();
                }

                public virtual void RowguidRules()
                {
                        this.RuleFor(x => x.Rowguid).NotNull();
                }

                public virtual void ShelfRules()
                {
                        this.RuleFor(x => x.Shelf).NotNull();
                        this.RuleFor(x => x.Shelf).Length(0, 10);
                }
        }
}

/*<Codenesium>
    <Hash>12f7b4e85344b2023afe00cf4fd475f4</Hash>
</Codenesium>*/