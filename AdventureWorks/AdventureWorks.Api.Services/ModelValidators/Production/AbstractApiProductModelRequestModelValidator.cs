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
        public abstract class AbstractApiProductModelRequestModelValidator: AbstractValidator<ApiProductModelRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiProductModelRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductModelRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IProductModelRepository ProductModelRepository { get; set; }
                public virtual void CatalogDescriptionRules()
                {
                }

                public virtual void InstructionsRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductModelRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiProductModelRequestModel model,  CancellationToken cancellationToken)
                {
                        ProductModel record = await this.ProductModelRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (int) && record.ProductModelID == this.existingRecordId))
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
    <Hash>0b6caf0d59dee865c27dc276a073996f</Hash>
</Codenesium>*/