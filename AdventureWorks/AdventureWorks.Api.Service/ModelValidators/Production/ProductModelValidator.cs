using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductModelValidator: AbstractProductModelValidator,IProductModelValidator
	{
		public ProductModelValidator()
		{   }

		public void CreateMode()
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
		}

		public void UpdateMode()
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
		}

		public void PatchMode()
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
		}
	}
}

/*<Codenesium>
    <Hash>831008f41d1ec87f09ec8fa206b67202</Hash>
</Codenesium>*/