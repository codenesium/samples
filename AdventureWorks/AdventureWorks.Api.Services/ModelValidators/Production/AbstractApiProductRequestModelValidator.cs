using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiProductRequestModelValidator : AbstractValidator<ApiProductRequestModel>
        {
                private int existingRecordId;

                private IProductRepository productRepository;

                public AbstractApiProductRequestModelValidator(IProductRepository productRepository)
                {
                        this.productRepository = productRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void @ClassRules()
                {
                        this.RuleFor(x => x.@Class).Length(0, 2);
                }

                public virtual void ColorRules()
                {
                        this.RuleFor(x => x.Color).Length(0, 15);
                }

                public virtual void DaysToManufactureRules()
                {
                }

                public virtual void DiscontinuedDateRules()
                {
                }

                public virtual void FinishedGoodsFlagRules()
                {
                }

                public virtual void ListPriceRules()
                {
                }

                public virtual void MakeFlagRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void ProductLineRules()
                {
                        this.RuleFor(x => x.ProductLine).Length(0, 2);
                }

                public virtual void ProductModelIDRules()
                {
                }

                public virtual void ProductNumberRules()
                {
                        this.RuleFor(x => x.ProductNumber).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByProductNumber).When(x => x?.ProductNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductRequestModel.ProductNumber));
                        this.RuleFor(x => x.ProductNumber).Length(0, 25);
                }

                public virtual void ProductSubcategoryIDRules()
                {
                }

                public virtual void ReorderPointRules()
                {
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void SafetyStockLevelRules()
                {
                }

                public virtual void SellEndDateRules()
                {
                }

                public virtual void SellStartDateRules()
                {
                }

                public virtual void SizeRules()
                {
                        this.RuleFor(x => x.Size).Length(0, 5);
                }

                public virtual void SizeUnitMeasureCodeRules()
                {
                        this.RuleFor(x => x.SizeUnitMeasureCode).Length(0, 3);
                }

                public virtual void StandardCostRules()
                {
                }

                public virtual void StyleRules()
                {
                        this.RuleFor(x => x.Style).Length(0, 2);
                }

                public virtual void WeightRules()
                {
                }

                public virtual void WeightUnitMeasureCodeRules()
                {
                        this.RuleFor(x => x.WeightUnitMeasureCode).Length(0, 3);
                }

                private async Task<bool> BeUniqueByName(ApiProductRequestModel model,  CancellationToken cancellationToken)
                {
                        Product record = await this.productRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default(int) && record.ProductID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }

                private async Task<bool> BeUniqueByProductNumber(ApiProductRequestModel model,  CancellationToken cancellationToken)
                {
                        Product record = await this.productRepository.ByProductNumber(model.ProductNumber);

                        if (record == null || (this.existingRecordId != default(int) && record.ProductID == this.existingRecordId))
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
    <Hash>2a5a1d9d2740a2329fc6535cd4ea1b62</Hash>
</Codenesium>*/