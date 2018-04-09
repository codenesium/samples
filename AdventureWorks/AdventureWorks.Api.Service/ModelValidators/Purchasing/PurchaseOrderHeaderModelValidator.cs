using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class PurchaseOrderHeaderModelValidator: AbstractPurchaseOrderHeaderModelValidator,IPurchaseOrderHeaderModelValidator
	{
		public PurchaseOrderHeaderModelValidator()
		{   }

		public void CreateMode()
		{
			this.RevisionNumberRules();
			this.StatusRules();
			this.EmployeeIDRules();
			this.VendorIDRules();
			this.ShipMethodIDRules();
			this.OrderDateRules();
			this.ShipDateRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.FreightRules();
			this.TotalDueRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.RevisionNumberRules();
			this.StatusRules();
			this.EmployeeIDRules();
			this.VendorIDRules();
			this.ShipMethodIDRules();
			this.OrderDateRules();
			this.ShipDateRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.FreightRules();
			this.TotalDueRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>af3b8b1e6d67b93ff3e2537b374cf97a</Hash>
</Codenesium>*/