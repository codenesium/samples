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

		public void PatchMode()
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
	}
}

/*<Codenesium>
    <Hash>cf6d3b44eb05ee00495cb3cf347d0a3c</Hash>
</Codenesium>*/