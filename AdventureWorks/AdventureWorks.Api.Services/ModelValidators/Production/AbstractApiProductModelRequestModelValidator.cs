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
        public abstract class AbstractApiProductModelRequestModelValidator : AbstractValidator<ApiProductModelRequestModel>
        {
                private int existingRecordId;

                private IProductModelRepository productModelRepository;

                public AbstractApiProductModelRequestModelValidator(IProductModelRepository productModelRepository)
                {
                        this.productModelRepository = productModelRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductModelRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CatalogDescriptionRules()
                {
                }

                public virtual void InstructionRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductModelRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                }

                private async Task<bool> BeUniqueByName(ApiProductModelRequestModel model,  CancellationToken cancellationToken)
                {
                        ProductModel record = await this.productModelRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default(int) && record.ProductModelID == this.existingRecordId))
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
    <Hash>25d9b5bc8d6e39aab80ef596047f6d54</Hash>
</Codenesium>*/