using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractProductModelValidator: AbstractValidator<ProductModel>
	{
		public new ValidationResult Validate(ProductModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IUnitMeasureRepository UnitMeasureRepository { get; set; }
		public IProductSubcategoryRepository ProductSubcategoryRepository { get; set; }
		public IProductModelRepository ProductModelRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void ProductNumberRules()
		{
			this.RuleFor(x => x.ProductNumber).NotNull();
			this.RuleFor(x => x.ProductNumber).Length(0, 25);
		}

		public virtual void MakeFlagRules()
		{
			this.RuleFor(x => x.MakeFlag).NotNull();
		}

		public virtual void FinishedGoodsFlagRules()
		{
			this.RuleFor(x => x.FinishedGoodsFlag).NotNull();
		}

		public virtual void ColorRules()
		{
			this.RuleFor(x => x.Color).Length(0, 15);
		}

		public virtual void SafetyStockLevelRules()
		{
			this.RuleFor(x => x.SafetyStockLevel).NotNull();
		}

		public virtual void ReorderPointRules()
		{
			this.RuleFor(x => x.ReorderPoint).NotNull();
		}

		public virtual void StandardCostRules()
		{
			this.RuleFor(x => x.StandardCost).NotNull();
		}

		public virtual void ListPriceRules()
		{
			this.RuleFor(x => x.ListPrice).NotNull();
		}

		public virtual void SizeRules()
		{
			this.RuleFor(x => x.Size).Length(0, 5);
		}

		public virtual void SizeUnitMeasureCodeRules()
		{
			this.RuleFor(x => x.SizeUnitMeasureCode).Must(this.BeValidUnitMeasure).When(x => x ?.SizeUnitMeasureCode != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.SizeUnitMeasureCode).Length(0, 3);
		}

		public virtual void WeightUnitMeasureCodeRules()
		{
			this.RuleFor(x => x.WeightUnitMeasureCode).Must(this.BeValidUnitMeasure).When(x => x ?.WeightUnitMeasureCode != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.WeightUnitMeasureCode).Length(0, 3);
		}

		public virtual void WeightRules()
		{                       }

		public virtual void DaysToManufactureRules()
		{
			this.RuleFor(x => x.DaysToManufacture).NotNull();
		}

		public virtual void ProductLineRules()
		{
			this.RuleFor(x => x.ProductLine).Length(0, 2);
		}

		public virtual void @ClassRules()
		{
			this.RuleFor(x => x.@Class).Length(0, 2);
		}

		public virtual void StyleRules()
		{
			this.RuleFor(x => x.Style).Length(0, 2);
		}

		public virtual void ProductSubcategoryIDRules()
		{
			this.RuleFor(x => x.ProductSubcategoryID).Must(this.BeValidProductSubcategory).When(x => x ?.ProductSubcategoryID != null).WithMessage("Invalid reference");
		}

		public virtual void ProductModelIDRules()
		{
			this.RuleFor(x => x.ProductModelID).Must(this.BeValidProductModel).When(x => x ?.ProductModelID != null).WithMessage("Invalid reference");
		}

		public virtual void SellStartDateRules()
		{
			this.RuleFor(x => x.SellStartDate).NotNull();
		}

		public virtual void SellEndDateRules()
		{                       }

		public virtual void DiscontinuedDateRules()
		{                       }

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidUnitMeasure(string id)
		{
			return this.UnitMeasureRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}

		private bool BeValidProductSubcategory(Nullable<int> id)
		{
			return this.ProductSubcategoryRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}

		private bool BeValidProductModel(Nullable<int> id)
		{
			return this.ProductModelRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}
	}
}

/*<Codenesium>
    <Hash>8e56da348bc3df4163cfa4fe7a5345e2</Hash>
</Codenesium>*/