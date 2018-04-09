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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>f07a540eaa3fb1c9bee84901f7770fd1</Hash>
</Codenesium>*/