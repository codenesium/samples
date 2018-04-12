using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductVendorModelValidator: AbstractProductVendorModelValidator, IProductVendorModelValidator
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
    <Hash>0129391cd52b1e0088b1c6fb69e31cba</Hash>
</Codenesium>*/