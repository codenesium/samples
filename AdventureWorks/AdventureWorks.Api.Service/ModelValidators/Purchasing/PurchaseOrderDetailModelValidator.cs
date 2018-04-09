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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>f3a9299abde65322f0e1eec5918b867b</Hash>
</Codenesium>*/