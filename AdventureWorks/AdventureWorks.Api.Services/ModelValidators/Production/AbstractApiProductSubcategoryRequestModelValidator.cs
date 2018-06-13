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
        public abstract class AbstractApiProductSubcategoryRequestModelValidator: AbstractValidator<ApiProductSubcategoryRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiProductSubcategoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductSubcategoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IProductSubcategoryRepository ProductSubcategoryRepository { get; set; }
                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductSubcategoryRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void ProductCategoryIDRules()
                {
                }

                public virtual void RowguidRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiProductSubcategoryRequestModel model,  CancellationToken cancellationToken)
                {
                        ProductSubcategory record = await this.ProductSubcategoryRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (int) && record.ProductSubcategoryID == this.existingRecordId))
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
    <Hash>81517fcb7325eb155f23b8a2d7524598</Hash>
</Codenesium>*/