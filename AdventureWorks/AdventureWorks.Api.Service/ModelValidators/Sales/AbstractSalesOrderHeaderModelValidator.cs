using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSalesOrderHeaderModelValidator: AbstractValidator<SalesOrderHeaderModel>
	{
		public new ValidationResult Validate(SalesOrderHeaderModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SalesOrderHeaderModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void RevisionNumberRules()
		{
			RuleFor(x => x.RevisionNumber).NotNull();
		}

		public virtual void OrderDateRules()
		{
			RuleFor(x => x.OrderDate).NotNull();
		}

		public virtual void DueDateRules()
		{
			RuleFor(x => x.DueDate).NotNull();
		}

		public virtual void ShipDateRules()
		{                       }

		public virtual void StatusRules()
		{
			RuleFor(x => x.Status).NotNull();
		}

		public virtual void OnlineOrderFlagRules()
		{
			RuleFor(x => x.OnlineOrderFlag).NotNull();
		}

		public virtual void SalesOrderNumberRules()
		{
			RuleFor(x => x.SalesOrderNumber).NotNull();
			RuleFor(x => x.SalesOrderNumber).Length(0,25);
		}

		public virtual void PurchaseOrderNumberRules()
		{
			RuleFor(x => x.PurchaseOrderNumber).Length(0,25);
		}

		public virtual void AccountNumberRules()
		{
			RuleFor(x => x.AccountNumber).Length(0,15);
		}

		public virtual void CustomerIDRules()
		{
			RuleFor(x => x.CustomerID).NotNull();
		}

		public virtual void SalesPersonIDRules()
		{                       }

		public virtual void TerritoryIDRules()
		{                       }

		public virtual void BillToAddressIDRules()
		{
			RuleFor(x => x.BillToAddressID).NotNull();
		}

		public virtual void ShipToAddressIDRules()
		{
			RuleFor(x => x.ShipToAddressID).NotNull();
		}

		public virtual void ShipMethodIDRules()
		{
			RuleFor(x => x.ShipMethodID).NotNull();
		}

		public virtual void CreditCardIDRules()
		{                       }

		public virtual void CreditCardApprovalCodeRules()
		{
			RuleFor(x => x.CreditCardApprovalCode).Length(0,15);
		}

		public virtual void CurrencyRateIDRules()
		{                       }

		public virtual void SubTotalRules()
		{
			RuleFor(x => x.SubTotal).NotNull();
		}

		public virtual void TaxAmtRules()
		{
			RuleFor(x => x.TaxAmt).NotNull();
		}

		public virtual void FreightRules()
		{
			RuleFor(x => x.Freight).NotNull();
		}

		public virtual void TotalDueRules()
		{
			RuleFor(x => x.TotalDue).NotNull();
		}

		public virtual void CommentRules()
		{
			RuleFor(x => x.Comment).Length(0,128);
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>05a54001b5a17d98d16c11652f12e219</Hash>
</Codenesium>*/