using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSalesOrderHeaderRequestModelValidator: AbstractValidator<ApiSalesOrderHeaderRequestModel>
	{
		public new ValidationResult Validate(ApiSalesOrderHeaderRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesOrderHeaderRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICreditCardRepository CreditCardRepository { get; set; }
		public ICurrencyRateRepository CurrencyRateRepository { get; set; }
		public ICustomerRepository CustomerRepository { get; set; }
		public ISalesPersonRepository SalesPersonRepository { get; set; }
		public ISalesTerritoryRepository SalesTerritoryRepository { get; set; }
		public ISalesOrderHeaderRepository SalesOrderHeaderRepository { get; set; }
		public virtual void AccountNumberRules()
		{
			this.RuleFor(x => x.AccountNumber).Length(0, 15);
		}

		public virtual void BillToAddressIDRules()
		{
			this.RuleFor(x => x.BillToAddressID).NotNull();
		}

		public virtual void CommentRules()
		{
			this.RuleFor(x => x.Comment).Length(0, 128);
		}

		public virtual void CreditCardApprovalCodeRules()
		{
			this.RuleFor(x => x.CreditCardApprovalCode).Length(0, 15);
		}

		public virtual void CreditCardIDRules()
		{
			this.RuleFor(x => x.CreditCardID).MustAsync(this.BeValidCreditCard).When(x => x ?.CreditCardID != null).WithMessage("Invalid reference");
		}

		public virtual void CurrencyRateIDRules()
		{
			this.RuleFor(x => x.CurrencyRateID).MustAsync(this.BeValidCurrencyRate).When(x => x ?.CurrencyRateID != null).WithMessage("Invalid reference");
		}

		public virtual void CustomerIDRules()
		{
			this.RuleFor(x => x.CustomerID).NotNull();
			this.RuleFor(x => x.CustomerID).MustAsync(this.BeValidCustomer).When(x => x ?.CustomerID != null).WithMessage("Invalid reference");
		}

		public virtual void DueDateRules()
		{
			this.RuleFor(x => x.DueDate).NotNull();
		}

		public virtual void FreightRules()
		{
			this.RuleFor(x => x.Freight).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void OnlineOrderFlagRules()
		{
			this.RuleFor(x => x.OnlineOrderFlag).NotNull();
		}

		public virtual void OrderDateRules()
		{
			this.RuleFor(x => x.OrderDate).NotNull();
		}

		public virtual void PurchaseOrderNumberRules()
		{
			this.RuleFor(x => x.PurchaseOrderNumber).Length(0, 25);
		}

		public virtual void RevisionNumberRules()
		{
			this.RuleFor(x => x.RevisionNumber).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SalesOrderNumberRules()
		{
			this.RuleFor(x => x.SalesOrderNumber).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetSalesOrderNumber).When(x => x ?.SalesOrderNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesOrderHeaderRequestModel.SalesOrderNumber));
			this.RuleFor(x => x.SalesOrderNumber).Length(0, 25);
		}

		public virtual void SalesPersonIDRules()
		{
			this.RuleFor(x => x.SalesPersonID).MustAsync(this.BeValidSalesPerson).When(x => x ?.SalesPersonID != null).WithMessage("Invalid reference");
		}

		public virtual void ShipDateRules()
		{                       }

		public virtual void ShipMethodIDRules()
		{
			this.RuleFor(x => x.ShipMethodID).NotNull();
		}

		public virtual void ShipToAddressIDRules()
		{
			this.RuleFor(x => x.ShipToAddressID).NotNull();
		}

		public virtual void StatusRules()
		{
			this.RuleFor(x => x.Status).NotNull();
		}

		public virtual void SubTotalRules()
		{
			this.RuleFor(x => x.SubTotal).NotNull();
		}

		public virtual void TaxAmtRules()
		{
			this.RuleFor(x => x.TaxAmt).NotNull();
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		public virtual void TotalDueRules()
		{
			this.RuleFor(x => x.TotalDue).NotNull();
		}

		private async Task<bool> BeValidCreditCard(Nullable<int> id,  CancellationToken cancellationToken)
		{
			var record = await this.CreditCardRepository.Get(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeValidCurrencyRate(Nullable<int> id,  CancellationToken cancellationToken)
		{
			var record = await this.CurrencyRateRepository.Get(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeValidCustomer(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CustomerRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidSalesPerson(Nullable<int> id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesPersonRepository.Get(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeValidSalesTerritory(Nullable<int> id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesTerritoryRepository.Get(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeUniqueGetSalesOrderNumber(ApiSalesOrderHeaderRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.SalesOrderHeaderRepository.GetSalesOrderNumber(model.SalesOrderNumber);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>0d176b403a424ca25e330b850220a8a9</Hash>
</Codenesium>*/