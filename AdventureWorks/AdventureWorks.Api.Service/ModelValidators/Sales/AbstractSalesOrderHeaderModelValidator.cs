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

		public bool BeValidCustomer(int id)
		{
			Response response = new Response();

			this.CustomerRepository.GetById(id,response);
			return response.Customers.Count > 0;
		}

		public bool BeValidSalesPerson(Nullable<int> id)
		{
			Response response = new Response();

			this.SalesPersonRepository.GetById(id.GetValueOrDefault(),response);
			return response.SalesPersons.Count > 0;
		}

		public bool BeValidSalesTerritory(Nullable<int> id)
		{
			Response response = new Response();

			this.SalesTerritoryRepository.GetById(id.GetValueOrDefault(),response);
			return response.SalesTerritories.Count > 0;
		}

		public bool BeValidAddress(int id)
		{
			Response response = new Response();

			this.AddressRepository.GetById(id,response);
			return response.Addresses.Count > 0;
		}

		public bool BeValidShipMethod(int id)
		{
			Response response = new Response();

			this.ShipMethodRepository.GetById(id,response);
			return response.ShipMethods.Count > 0;
		}

		public bool BeValidCreditCard(Nullable<int> id)
		{
			Response response = new Response();

			this.CreditCardRepository.GetById(id.GetValueOrDefault(),response);
			return response.CreditCards.Count > 0;
		}

		public bool BeValidCurrencyRate(Nullable<int> id)
		{
			Response response = new Response();

			this.CurrencyRateRepository.GetById(id.GetValueOrDefault(),response);
			return response.CurrencyRates.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>c102714eb40a7b94217db89281dd2d10</Hash>
</Codenesium>*/