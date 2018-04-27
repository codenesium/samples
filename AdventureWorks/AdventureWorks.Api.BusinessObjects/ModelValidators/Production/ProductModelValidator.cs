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
			this.@ClassRules();
			this.ColorRules();
			this.DaysToManufactureRules();
			this.DiscontinuedDateRules();
			this.FinishedGoodsFlagRules();
			this.ListPriceRules();
			this.MakeFlagRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.ProductLineRules();
			this.ProductModelIDRules();
			this.ProductNumberRules();
			this.ProductSubcategoryIDRules();
			this.ReorderPointRules();
			this.RowguidRules();
			this.SafetyStockLevelRules();
			this.SellEndDateRules();
			this.SellStartDateRules();
			this.SizeRules();
			this.SizeUnitMeasureCodeRules();
			this.StandardCostRules();
			this.StyleRules();
			this.WeightRules();
			this.WeightUnitMeasureCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductModel model)
		{
			this.@ClassRules();
			this.ColorRules();
			this.DaysToManufactureRules();
			this.DiscontinuedDateRules();
			this.FinishedGoodsFlagRules();
			this.ListPriceRules();
			this.MakeFlagRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.ProductLineRules();
			this.ProductModelIDRules();
			this.ProductNumberRules();
			this.ProductSubcategoryIDRules();
			this.ReorderPointRules();
			this.RowguidRules();
			this.SafetyStockLevelRules();
			this.SellEndDateRules();
			this.SellStartDateRules();
			this.SizeRules();
			this.SizeUnitMeasureCodeRules();
			this.StandardCostRules();
			this.StyleRules();
			this.WeightRules();
			this.WeightUnitMeasureCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>0514b0b9a826f8110944aa6549c70f17</Hash>
</Codenesium>*/