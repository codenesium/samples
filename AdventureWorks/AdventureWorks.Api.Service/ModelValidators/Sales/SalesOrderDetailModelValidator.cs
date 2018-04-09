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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>85b43bfbc4b3eadc1dceea5531fc8c18</Hash>
</Codenesium>*/