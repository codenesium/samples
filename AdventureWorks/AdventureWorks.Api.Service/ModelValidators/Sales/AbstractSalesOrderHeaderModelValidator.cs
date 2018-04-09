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

		public ICustomerRepository CustomerRepository {get; set;}
		public ISalesPersonRepository SalesPersonRepository {get; set;}
		public ISalesTerritoryRepository SalesTerritoryRepository {get; set;}
		public IAddressRepository AddressRepository {get; set;}
		public IShipMethodRepository ShipMethodRepository {get; set;}
		public ICreditCardRepository CreditCardRepository {get; set;}
		public ICurrencyRateRepository CurrencyRateRepository {get; set;}
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
			RuleFor(x => x.CustomerID).Must(BeValidCustomer).When(x => x ?.CustomerID != null).WithMessage("Invalid reference");
		}

		public virtual void SalesPersonIDRules()
		{
			RuleFor(x => x.SalesPersonID).Must(BeValidSalesPerson).When(x => x ?.SalesPersonID != null).WithMessage("Invalid reference");
		}

		public virtual void TerritoryIDRules()
		{
			RuleFor(x => x.TerritoryID).Must(BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		public virtual void BillToAddressIDRules()
		{
			RuleFor(x => x.BillToAddressID).NotNull();
			RuleFor(x => x.BillToAddressID).Must(BeValidAddress).When(x => x ?.BillToAddressID != null).WithMessage("Invalid reference");
		}

		public virtual void ShipToAddressIDRules()
		{
			RuleFor(x => x.ShipToAddressID).NotNull();
			RuleFor(x => x.ShipToAddressID).Must(BeValidAddress).When(x => x ?.ShipToAddressID != null).WithMessage("Invalid reference");
		}

		public virtual void ShipMethodIDRules()
		{
			RuleFor(x => x.ShipMethodID).NotNull();
			RuleFor(x => x.ShipMethodID).Must(BeValidShipMethod).When(x => x ?.ShipMethodID != null).WithMessage("Invalid reference");
		}

		public virtual void CreditCardIDRules()
		{
			RuleFor(x => x.CreditCardID).Must(BeValidCreditCard).When(x => x ?.CreditCardID != null).WithMessage("Invalid reference");
		}

		public virtual void CreditCardApprovalCodeRules()
		{
			RuleFor(x => x.CreditCardApprovalCode).Length(0,15);
		}

		public virtual void CurrencyRateIDRules()
		{
			RuleFor(x => x.CurrencyRateID).Must(BeValidCurrencyRate).When(x => x ?.CurrencyRateID != null).WithMessage("Invalid reference");
		}

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
    <Hash>94fae84774c84e6c0f83be4d35c0eb70</Hash>
</Codenesium>*/