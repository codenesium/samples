using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductVendorModelValidator: AbstractProductVendorModelValidator,IProductVendorModelValidator
	{
		public ProductVendorModelValidator()
		{   }

		public void CreateMode()
		{
			this.BusinessEntityIDRules();
			this.AverageLeadTimeRules();
			this.StandardPriceRules();
			this.LastReceiptCostRules();
			this.LastReceiptDateRules();
			this.MinOrderQtyRules();
			this.MaxOrderQtyRules();
			this.OnOrderQtyRules();
			this.UnitMeasureCodeRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.BusinessEntityIDRules();
			this.AverageLeadTimeRules();
			this.StandardPriceRules();
			this.LastReceiptCostRules();
			this.LastReceiptDateRules();
			this.MinOrderQtyRules();
			this.MaxOrderQtyRules();
			this.OnOrderQtyRules();
			this.UnitMeasureCodeRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.BusinessEntityIDRules();
			this.AverageLeadTimeRules();
			this.StandardPriceRules();
			this.LastReceiptCostRules();
			this.LastReceiptDateRules();
			this.MinOrderQtyRules();
			this.MaxOrderQtyRules();
			this.OnOrderQtyRules();
			this.UnitMeasureCodeRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>b4c87a54c973ce5cc733b81640d77558</Hash>
</Codenesium>*/