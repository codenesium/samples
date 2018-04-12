using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class PurchaseOrderHeaderModelValidator: AbstractPurchaseOrderHeaderModelValidator, IPurchaseOrderHeaderModelValidator
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
    <Hash>0b77ee9a41cf1a5a7fc2006f645a04a3</Hash>
</Codenesium>*/