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
        public abstract class AbstractApiProductCategoryRequestModelValidator: AbstractValidator<ApiProductCategoryRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiProductCategoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductCategoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IProductCategoryRepository ProductCategoryRepository { get; set; }
                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductCategoryRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                        this.RuleFor(x => x.Rowguid).NotNull();
                }

                private async Task<bool> BeUniqueGetName(ApiProductCategoryRequestModel model,  CancellationToken cancellationToken)
                {
                        ProductCategory record = await this.ProductCategoryRepository.GetName(model.Name);

                        if (record == null || record.ProductCategoryID == this.existingRecordId)
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
    <Hash>2f47d070d2fb214752543b482ad417c9</Hash>
</Codenesium>*/