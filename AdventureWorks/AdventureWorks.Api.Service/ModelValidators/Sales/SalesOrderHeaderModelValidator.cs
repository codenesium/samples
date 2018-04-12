using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class SalesOrderHeaderModelValidator: AbstractSalesOrderHeaderModelValidator, ISalesOrderHeaderModelValidator
	{
		public SalesOrderHeaderModelValidator()
		{   }

		public void CreateMode()
		{
			this.RevisionNumberRules();
			this.OrderDateRules();
			this.DueDateRules();
			this.ShipDateRules();
			this.StatusRules();
			this.OnlineOrderFlagRules();
			this.SalesOrderNumberRules();
			this.PurchaseOrderNumberRules();
			this.AccountNumberRules();
			this.CustomerIDRules();
			this.SalesPersonIDRules();
			this.TerritoryIDRules();
			this.BillToAddressIDRules();
			this.ShipToAddressIDRules();
			this.ShipMethodIDRules();
			this.CreditCardIDRules();
			this.CreditCardApprovalCodeRules();
			this.CurrencyRateIDRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.FreightRules();
			this.TotalDueRules();
			this.CommentRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.RevisionNumberRules();
			this.OrderDateRules();
			this.DueDateRules();
			this.ShipDateRules();
			this.StatusRules();
			this.OnlineOrderFlagRules();
			this.SalesOrderNumberRules();
			this.PurchaseOrderNumberRules();
			this.AccountNumberRules();
			this.CustomerIDRules();
			this.SalesPersonIDRules();
			this.TerritoryIDRules();
			this.BillToAddressIDRules();
			this.ShipToAddressIDRules();
			this.ShipMethodIDRules();
			this.CreditCardIDRules();
			this.CreditCardApprovalCodeRules();
			this.CurrencyRateIDRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.FreightRules();
			this.TotalDueRules();
			this.CommentRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>a2dd5e5aff178614ea5a97c7a987b994</Hash>
</Codenesium>*/