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

		public ICustomerRepository CustomerRepository { get; set; }
		public ISalesPersonRepository SalesPersonRepository { get; set; }
		public ISalesTerritoryRepository SalesTerritoryRepository { get; set; }
		public IAddressRepository AddressRepository { get; set; }
		public IShipMethodRepository ShipMethodRepository { get; set; }
		public ICreditCardRepository CreditCardRepository { get; set; }
		public ICurrencyRateRepository CurrencyRateRepository { get; set; }
		public virtual void RevisionNumberRules()
		{
			this.RuleFor(x => x.RevisionNumber).NotNull();
		}

		public virtual void OrderDateRules()
		{
			this.RuleFor(x => x.OrderDate).NotNull();
		}

		public virtual void DueDateRules()
		{
			this.RuleFor(x => x.DueDate).NotNull();
		}

		public virtual void ShipDateRules()
		{                       }

		public virtual void StatusRules()
		{
			this.RuleFor(x => x.Status).NotNull();
		}

		public virtual void OnlineOrderFlagRules()
		{
			this.RuleFor(x => x.OnlineOrderFlag).NotNull();
		}

		public virtual void SalesOrderNumberRules()
		{
			this.RuleFor(x => x.SalesOrderNumber).NotNull();
			this.RuleFor(x => x.SalesOrderNumber).Length(0, 25);
		}

		public virtual void PurchaseOrderNumberRules()
		{
			this.RuleFor(x => x.PurchaseOrderNumber).Length(0, 25);
		}

		public virtual void AccountNumberRules()
		{
			this.RuleFor(x => x.AccountNumber).Length(0, 15);
		}

		public virtual void CustomerIDRules()
		{
			this.RuleFor(x => x.CustomerID).NotNull();
			this.RuleFor(x => x.CustomerID).Must(this.BeValidCustomer).When(x => x ?.CustomerID != null).WithMessage("Invalid reference");
		}

		public virtual void SalesPersonIDRules()
		{
			this.RuleFor(x => x.SalesPersonID).Must(this.BeValidSalesPerson).When(x => x ?.SalesPersonID != null).WithMessage("Invalid reference");
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).Must(this.BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		public virtual void BillToAddressIDRules()
		{
			this.RuleFor(x => x.BillToAddressID).NotNull();
			this.RuleFor(x => x.BillToAddressID).Must(this.BeValidAddress).When(x => x ?.BillToAddressID != null).WithMessage("Invalid reference");
		}

		public virtual void ShipToAddressIDRules()
		{
			this.RuleFor(x => x.ShipToAddressID).NotNull();
			this.RuleFor(x => x.ShipToAddressID).Must(this.BeValidAddress).When(x => x ?.ShipToAddressID != null).WithMessage("Invalid reference");
		}

		public virtual void ShipMethodIDRules()
		{
			this.RuleFor(x => x.ShipMethodID).NotNull();
			this.RuleFor(x => x.ShipMethodID).Must(this.BeValidShipMethod).When(x => x ?.ShipMethodID != null).WithMessage("Invalid reference");
		}

		public virtual void CreditCardIDRules()
		{
			this.RuleFor(x => x.CreditCardID).Must(this.BeValidCreditCard).When(x => x ?.CreditCardID != null).WithMessage("Invalid reference");
		}

		public virtual void CreditCardApprovalCodeRules()
		{
			this.RuleFor(x => x.CreditCardApprovalCode).Length(0, 15);
		}

		public virtual void CurrencyRateIDRules()
		{
			this.RuleFor(x => x.CurrencyRateID).Must(this.BeValidCurrencyRate).When(x => x ?.CurrencyRateID != null).WithMessage("Invalid reference");
		}

		public virtual void SubTotalRules()
		{
			this.RuleFor(x => x.SubTotal).NotNull();
		}

		public virtual void TaxAmtRules()
		{
			this.RuleFor(x => x.TaxAmt).NotNull();
		}

		public virtual void FreightRules()
		{
			this.RuleFor(x => x.Freight).NotNull();
		}

		public virtual void TotalDueRules()
		{
			this.RuleFor(x => x.TotalDue).NotNull();
		}

		public virtual void CommentRules()
		{
			this.RuleFor(x => x.Comment).Length(0, 128);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidCustomer(int id)
		{
			return this.CustomerRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidSalesPerson(Nullable<int> id)
		{
			return this.SalesPersonRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}

		private bool BeValidSalesTerritory(Nullable<int> id)
		{
			return this.SalesTerritoryRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}

		private bool BeValidAddress(int id)
		{
			return this.AddressRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidShipMethod(int id)
		{
			return this.ShipMethodRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidCreditCard(Nullable<int> id)
		{
			return this.CreditCardRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}

		private bool BeValidCurrencyRate(Nullable<int> id)
		{
			return this.CurrencyRateRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}
	}
}

/*<Codenesium>
    <Hash>2c0aee7775c4eae360a2f17f29c45a63</Hash>
</Codenesium>*/