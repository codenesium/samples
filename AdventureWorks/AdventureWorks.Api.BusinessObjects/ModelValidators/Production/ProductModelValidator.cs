using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductModelValidator: AbstractProductModelValidator, IProductModelValidator
	{
		public ProductModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductModel model)
		{
			this.NameRules();
			this.ProductNumberRules();
			this.MakeFlagRules();
			this.FinishedGoodsFlagRules();
			this.ColorRules();
			this.SafetyStockLevelRules();
			this.ReorderPointRules();
			this.StandardCostRules();
			this.ListPriceRules();
			this.SizeRules();
			this.SizeUnitMeasureCodeRules();
			this.WeightUnitMeasureCodeRules();
			this.WeightRules();
			this.DaysToManufactureRules();
			this.ProductLineRules();
			this.@ClassRules();
			this.StyleRules();
			this.ProductSubcategoryIDRules();
			this.ProductModelIDRules();
			this.SellStartDateRules();
			this.SellEndDateRules();
			this.DiscontinuedDateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductModel model)
		{
			this.NameRules();
			this.ProductNumberRules();
			this.MakeFlagRules();
			this.FinishedGoodsFlagRules();
			this.ColorRules();
			this.SafetyStockLevelRules();
			this.ReorderPointRules();
			this.StandardCostRules();
			this.ListPriceRules();
			this.SizeRules();
			this.SizeUnitMeasureCodeRules();
			this.WeightUnitMeasureCodeRules();
			this.WeightRules();
			this.DaysToManufactureRules();
			this.ProductLineRules();
			this.@ClassRules();
			this.StyleRules();
			this.ProductSubcategoryIDRules();
			this.ProductModelIDRules();
			this.SellStartDateRules();
			this.SellEndDateRules();
			this.DiscontinuedDateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>5ba5959f878fe5cbbdf85351df2f611f</Hash>
</Codenesium>*/