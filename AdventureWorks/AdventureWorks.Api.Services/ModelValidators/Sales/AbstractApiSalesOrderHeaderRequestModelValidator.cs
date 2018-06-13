using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiSalesOrderHeaderRequestModelValidator: AbstractValidator<ApiSalesOrderHeaderRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSalesOrderHeaderRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSalesOrderHeaderRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
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
                        this.RuleFor(x => x.CustomerID).MustAsync(this.BeValidCustomer).When(x => x ?.CustomerID != null).WithMessage("Invalid reference");
                }

                public virtual void DueDateRules()
                {
                }

                public virtual void FreightRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void OnlineOrderFlagRules()
                {
                }

                public virtual void OrderDateRules()
                {
                }

                public virtual void PurchaseOrderNumberRules()
                {
                        this.RuleFor(x => x.PurchaseOrderNumber).Length(0, 25);
                }

                public virtual void RevisionNumberRules()
                {
                }

                public virtual void RowguidRules()
                {
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
                {
                }

                public virtual void ShipMethodIDRules()
                {
                }

                public virtual void ShipToAddressIDRules()
                {
                }

                public virtual void StatusRules()
                {
                }

                public virtual void SubTotalRules()
                {
                }

                public virtual void TaxAmtRules()
                {
                }

                public virtual void TerritoryIDRules()
                {
                        this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
                }

                public virtual void TotalDueRules()
                {
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
                        SalesOrderHeader record = await this.SalesOrderHeaderRepository.GetSalesOrderNumber(model.SalesOrderNumber);

                        if (record == null || (this.existingRecordId != default (int) && record.SalesOrderID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>ce10157cbed702194547c9e73956740f</Hash>
</Codenesium>*/