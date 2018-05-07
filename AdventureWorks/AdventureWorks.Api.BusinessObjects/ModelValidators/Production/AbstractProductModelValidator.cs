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
			this.RuleFor(x => x.DaysToManufacture).NotNull();
		}

		public virtual void DiscontinuedDateRules()
		{                       }

		public virtual void FinishedGoodsFlagRules()
		{
			this.RuleFor(x => x.FinishedGoodsFlag).NotNull();
		}

		public virtual void ListPriceRules()
		{
			this.RuleFor(x => x.ListPrice).NotNull();
		}

		public virtual void MakeFlagRules()
		{
			this.RuleFor(x => x.MakeFlag).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void ProductLineRules()
		{
			this.RuleFor(x => x.ProductLine).Length(0, 2);
		}

		public virtual void ProductModelIDRules()
		{                       }

		public virtual void ProductNumberRules()
		{
			this.RuleFor(x => x.ProductNumber).NotNull();
			this.RuleFor(x => x.ProductNumber).Length(0, 25);
		}

		public virtual void ProductSubcategoryIDRules()
		{                       }

		public virtual void ReorderPointRules()
		{
			this.RuleFor(x => x.ReorderPoint).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SafetyStockLevelRules()
		{
			this.RuleFor(x => x.SafetyStockLevel).NotNull();
		}

		public virtual void SellEndDateRules()
		{                       }

		public virtual void SellStartDateRules()
		{
			this.RuleFor(x => x.SellStartDate).NotNull();
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
			this.RuleFor(x => x.StandardCost).NotNull();
		}

		public virtual void StyleRules()
		{
			this.RuleFor(x => x.Style).Length(0, 2);
		}

		public virtual void WeightRules()
		{                       }

		public virtual void WeightUnitMeasureCodeRules()
		{
			this.RuleFor(x => x.WeightUnitMeasureCode).Length(0, 3);
		}
	}
}

/*<Codenesium>
    <Hash>beb0c75ccaef067f4b835178650f6c4f</Hash>
</Codenesium>*/