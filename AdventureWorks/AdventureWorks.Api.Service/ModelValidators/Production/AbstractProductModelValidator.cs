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

		public IUnitMeasureRepository UnitMeasureRepository {get; set;}
		public IProductSubcategoryRepository ProductSubcategoryRepository {get; set;}
		public IProductModelRepository ProductModelRepository {get; set;}
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
			RuleFor(x => x.SizeUnitMeasureCode).Must(BeValidUnitMeasure).When(x => x ?.SizeUnitMeasureCode != null).WithMessage("Invalid reference");
			RuleFor(x => x.SizeUnitMeasureCode).Length(0,3);
		}

		public virtual void WeightUnitMeasureCodeRules()
		{
			RuleFor(x => x.WeightUnitMeasureCode).Must(BeValidUnitMeasure).When(x => x ?.WeightUnitMeasureCode != null).WithMessage("Invalid reference");
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
		{
			RuleFor(x => x.ProductSubcategoryID).Must(BeValidProductSubcategory).When(x => x ?.ProductSubcategoryID != null).WithMessage("Invalid reference");
		}

		public virtual void ProductModelIDRules()
		{
			RuleFor(x => x.ProductModelID).Must(BeValidProductModel).When(x => x ?.ProductModelID != null).WithMessage("Invalid reference");
		}

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

		public bool BeValidUnitMeasure(string id)
		{
			Response response = new Response();

			this.UnitMeasureRepository.GetById(id.GetValueOrDefault(),response);
			return response.UnitMeasures.Count > 0;
		}

		public bool BeValidProductSubcategory(Nullable<int> id)
		{
			Response response = new Response();

			this.ProductSubcategoryRepository.GetById(id.GetValueOrDefault(),response);
			return response.ProductSubcategories.Count > 0;
		}

		public bool BeValidProductModel(Nullable<int> id)
		{
			Response response = new Response();

			this.ProductModelRepository.GetById(id.GetValueOrDefault(),response);
			return response.ProductModels.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>bc7f3e8f9932e95a51486b4d8ce75836</Hash>
</Codenesium>*/