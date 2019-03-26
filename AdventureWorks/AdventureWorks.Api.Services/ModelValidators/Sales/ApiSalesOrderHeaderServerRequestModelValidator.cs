using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesOrderHeaderServerRequestModelValidator : AbstractApiSalesOrderHeaderServerRequestModelValidator, IApiSalesOrderHeaderServerRequestModelValidator
	{
		public ApiSalesOrderHeaderServerRequestModelValidator(ISalesOrderHeaderRepository salesOrderHeaderRepository)
			: base(salesOrderHeaderRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderServerRequestModel model)
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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>366d53e4e1b129fdf3ea7ab95c3667de</Hash>
</Codenesium>*/