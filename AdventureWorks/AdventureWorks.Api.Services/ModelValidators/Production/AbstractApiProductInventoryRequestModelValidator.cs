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
                }

                public virtual void LocationIDRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void QuantityRules()
                {
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void ShelfRules()
                {
                        this.RuleFor(x => x.Shelf).NotNull();
                        this.RuleFor(x => x.Shelf).Length(0, 10);
                }
        }
}

/*<Codenesium>
    <Hash>85485285a43c753a925452347e4473ae</Hash>
</Codenesium>*/