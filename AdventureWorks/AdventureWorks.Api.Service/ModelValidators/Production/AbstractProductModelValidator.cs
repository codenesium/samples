using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void ProductNumberRules()
		{
			RuleFor(x => x.ProductNumber).NotNull();
			RuleFor(x => x.ProductNumber).Length(0,25);
		}

		public virtual void MakeFlagRules()
		{
			RuleFor(x => x.MakeFlag).NotNull();
		}

		public virtual void FinishedGoodsFlagRules()
		{
			RuleFor(x => x.FinishedGoodsFlag).NotNull();
		}

		public virtual void ColorRules()
		{
			RuleFor(x => x.Color).Length(0,15);
		}

		public virtual void SafetyStockLevelRules()
		{
			RuleFor(x => x.SafetyStockLevel).NotNull();
		}

		public virtual void ReorderPointRules()
		{
			RuleFor(x => x.ReorderPoint).NotNull();
		}

		public virtual void StandardCostRules()
		{
			RuleFor(x => x.StandardCost).NotNull();
		}

		public virtual void ListPriceRules()
		{
			RuleFor(x => x.ListPrice).NotNull();
		}

		public virtual void SizeRules()
		{
			RuleFor(x => x.Size).Length(0,5);
		}

		public virtual void SizeUnitMeasureCodeRules()
		{
			RuleFor(x => x.SizeUnitMeasureCode).Length(0,3);
		}

		public virtual void WeightUnitMeasureCodeRules()
		{
			RuleFor(x => x.WeightUnitMeasureCode).Length(0,3);
		}

		public virtual void WeightRules()
		{                       }

		public virtual void DaysToManufactureRules()
		{
			RuleFor(x => x.DaysToManufacture).NotNull();
		}

		public virtual void ProductLineRules()
		{
			RuleFor(x => x.ProductLine).Length(0,2);
		}

		public virtual void @ClassRules()
		{
			RuleFor(x => x.@Class).Length(0,2);
		}

		public virtual void StyleRules()
		{
			RuleFor(x => x.Style).Length(0,2);
		}

		public virtual void ProductSubcategoryIDRules()
		{                       }

		public virtual void ProductModelIDRules()
		{                       }

		public virtual void SellStartDateRules()
		{
			RuleFor(x => x.SellStartDate).NotNull();
		}

		public virtual void SellEndDateRules()
		{                       }

		public virtual void DiscontinuedDateRules()
		{                       }

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>818ef1b6385e2a4278d6d6a6080f03c5</Hash>
</Codenesium>*/