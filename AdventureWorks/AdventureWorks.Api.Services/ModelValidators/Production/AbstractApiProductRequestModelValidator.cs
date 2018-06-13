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
        public abstract class AbstractApiProductRequestModelValidator: AbstractValidator<ApiProductRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiProductRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IProductRepository ProductRepository { get; set; }
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductRequestModel.Name));
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetProductNumber).When(x => x ?.ProductNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductRequestModel.ProductNumber));
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

                private async Task<bool> BeUniqueGetName(ApiProductRequestModel model,  CancellationToken cancellationToken)
                {
                        Product record = await this.ProductRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (int) && record.ProductID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
                private async Task<bool> BeUniqueGetProductNumber(ApiProductRequestModel model,  CancellationToken cancellationToken)
                {
                        Product record = await this.ProductRepository.GetProductNumber(model.ProductNumber);

                        if (record == null || (this.existingRecordId != default (int) && record.ProductID == this.existingRecordId))
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
    <Hash>594b2488420d3814c1fd38cf4fa0214f</Hash>
</Codenesium>*/