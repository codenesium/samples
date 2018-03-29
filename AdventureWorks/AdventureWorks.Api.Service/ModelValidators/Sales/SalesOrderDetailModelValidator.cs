using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class SalesOrderDetailModelValidator: AbstractSalesOrderDetailModelValidator,ISalesOrderDetailModelValidator
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

		public void PatchMode()
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
	}
}

/*<Codenesium>
    <Hash>d449b4e15c97e8952b1f6b7dcd5ca1e7</Hash>
</Codenesium>*/