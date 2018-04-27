using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class SalesOrderHeaderModelValidator: AbstractSalesOrderHeaderModelValidator, ISalesOrderHeaderModelValidator
	{
		public SalesOrderHeaderModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SalesOrderHeaderModel model)
		{
			this.AccountNumberRules();
			this.BillToAddressIDRules();
			this.CommentRules();
			this.CreditCardApprovalCodeRules();
			this.CreditCardIDRules();
			this.CurrencyRateIDRules();
			this.CustomerIDRules();
			this.DueDateRules();
			this.FreightRules();
			this.ModifiedDateRules();
			this.OnlineOrderFlagRules();
			this.OrderDateRules();
			this.PurchaseOrderNumberRules();
			this.RevisionNumberRules();
			this.RowguidRules();
			this.SalesOrderNumberRules();
			this.SalesPersonIDRules();
			this.ShipDateRules();
			this.ShipMethodIDRules();
			this.ShipToAddressIDRules();
			this.StatusRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.TerritoryIDRules();
			this.TotalDueRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesOrderHeaderModel model)
		{
			this.AccountNumberRules();
			this.BillToAddressIDRules();
			this.CommentRules();
			this.CreditCardApprovalCodeRules();
			this.CreditCardIDRules();
			this.CurrencyRateIDRules();
			this.CustomerIDRules();
			this.DueDateRules();
			this.FreightRules();
			this.ModifiedDateRules();
			this.OnlineOrderFlagRules();
			this.OrderDateRules();
			this.PurchaseOrderNumberRules();
			this.RevisionNumberRules();
			this.RowguidRules();
			this.SalesOrderNumberRules();
			this.SalesPersonIDRules();
			this.ShipDateRules();
			this.ShipMethodIDRules();
			this.ShipToAddressIDRules();
			this.StatusRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.TerritoryIDRules();
			this.TotalDueRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>151d9e02a38faf273b40532d25639e9f</Hash>
</Codenesium>*/