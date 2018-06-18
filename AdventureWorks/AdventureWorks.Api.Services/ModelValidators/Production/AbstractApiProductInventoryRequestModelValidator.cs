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

                IProductInventoryRepository productInventoryRepository;

                public AbstractApiProductInventoryRequestModelValidator(IProductInventoryRepository productInventoryRepository)
                {
                        this.productInventoryRepository = productInventoryRepository;
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
    <Hash>a49becce6aaef7d6d5342ced66acee93</Hash>
</Codenesium>*/