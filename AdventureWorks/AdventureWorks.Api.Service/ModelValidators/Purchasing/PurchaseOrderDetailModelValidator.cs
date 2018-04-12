using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class PurchaseOrderDetailModelValidator: AbstractPurchaseOrderDetailModelValidator, IPurchaseOrderDetailModelValidator
	{
		public PurchaseOrderDetailModelValidator()
		{   }

		public void CreateMode()
		{
			this.PurchaseOrderDetailIDRules();
			this.DueDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.UnitPriceRules();
			this.LineTotalRules();
			this.ReceivedQtyRules();
			this.RejectedQtyRules();
			this.StockedQtyRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.PurchaseOrderDetailIDRules();
			this.DueDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.UnitPriceRules();
			this.LineTotalRules();
			this.ReceivedQtyRules();
			this.RejectedQtyRules();
			this.StockedQtyRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>7c120c480fe83ce9a93ef0a69d048f16</Hash>
</Codenesium>*/