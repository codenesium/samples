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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesOrderHeaderModel model)
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b3cc7bcb768f54050026ad70ed5f9f24</Hash>
</Codenesium>*/