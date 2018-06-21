using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiProductSubcategoryRequestModelValidator : AbstractValidator<ApiProductSubcategoryRequestModel>
        {
                private int existingRecordId;

                private IProductSubcategoryRepository productSubcategoryRepository;

                public AbstractApiProductSubcategoryRequestModelValidator(IProductSubcategoryRepository productSubcategoryRepository)
                {
                        this.productSubcategoryRepository = productSubcategoryRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductSubcategoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductSubcategoryRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void ProductCategoryIDRules()
                {
                }

                public virtual void RowguidRules()
                {
                }

                private async Task<bool> BeUniqueByName(ApiProductSubcategoryRequestModel model,  CancellationToken cancellationToken)
                {
                        ProductSubcategory record = await this.productSubcategoryRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default(int) && record.ProductSubcategoryID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f6cc18df1b368e89aa11c9ac2d6c557a</Hash>
</Codenesium>*/