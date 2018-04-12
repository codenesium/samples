using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class SalesOrderDetailModelValidator: AbstractSalesOrderDetailModelValidator, ISalesOrderDetailModelValidator
	{
		public SalesOrderDetailModelValidator()
		{   }

		public void CreateMode()
		{
			this.SalesOrderDetailIDRules();
			this.CarrierTrackingNumberRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.SpecialOfferIDRules();
			this.UnitPriceRules();
			this.UnitPriceDiscountRules();
			this.LineTotalRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.SalesOrderDetailIDRules();
			this.CarrierTrackingNumberRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.SpecialOfferIDRules();
			this.UnitPriceRules();
			this.UnitPriceDiscountRules();
			this.LineTotalRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>ecfb4b1870761c313f716dc31eaeea18</Hash>
</Codenesium>*/