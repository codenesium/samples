using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class PurchaseOrderDetailModelValidator: AbstractPurchaseOrderDetailModelValidator,IPurchaseOrderDetailModelValidator
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

		public void PatchMode()
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
	}
}

/*<Codenesium>
    <Hash>cf2e41bc626f50a2e06bba974930edaa</Hash>
</Codenesium>*/