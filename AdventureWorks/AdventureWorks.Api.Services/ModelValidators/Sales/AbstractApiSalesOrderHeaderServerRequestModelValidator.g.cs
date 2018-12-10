using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSalesOrderHeaderServerRequestModelValidator : AbstractValidator<ApiSalesOrderHeaderServerRequestModel>
	{
		private int existingRecordId;

		protected ISalesOrderHeaderRepository SalesOrderHeaderRepository { get; private set; }

		public AbstractApiSalesOrderHeaderServerRequestModelValidator(ISalesOrderHeaderRepository salesOrderHeaderRepository)
		{
			this.SalesOrderHeaderRepository = salesOrderHeaderRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesOrderHeaderServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AccountNumberRules()
		{
			this.RuleFor(x => x.AccountNumber).Length(0, 15).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void BillToAddressIDRules()
		{
		}

		public virtual void CommentRules()
		{
			this.RuleFor(x => x.Comment).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void CreditCardApprovalCodeRules()
		{
			this.RuleFor(x => x.CreditCardApprovalCode).Length(0, 15).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void CreditCardIDRules()
		{
			this.RuleFor(x => x.CreditCardID).MustAsync(this.BeValidCreditCardByCreditCardID).When(x => !x?.CreditCardID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void CurrencyRateIDRules()
		{
			this.RuleFor(x => x.CurrencyRateID).MustAsync(this.BeValidCurrencyRateByCurrencyRateID).When(x => !x?.CurrencyRateID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void CustomerIDRules()
		{
			this.RuleFor(x => x.CustomerID).MustAsync(this.BeValidCustomerByCustomerID).When(x => !x?.CustomerID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
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
			this.RuleFor(x => x.PurchaseOrderNumber).Length(0, 25).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RevisionNumberRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesOrderHeaderServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void SalesOrderNumberRules()
		{
			this.RuleFor(x => x.SalesOrderNumber).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueBySalesOrderNumber).When(x => (!x?.SalesOrderNumber.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesOrderHeaderServerRequestModel.SalesOrderNumber)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.SalesOrderNumber).Length(0, 25).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void SalesPersonIDRules()
		{
			this.RuleFor(x => x.SalesPersonID).MustAsync(this.BeValidSalesPersonBySalesPersonID).When(x => !x?.SalesPersonID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
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
			this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritoryByTerritoryID).When(x => !x?.TerritoryID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TotalDueRules()
		{
		}

		protected async Task<bool> BeValidCreditCardByCreditCardID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesOrderHeaderRepository.CreditCardByCreditCardID(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidCurrencyRateByCurrencyRateID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesOrderHeaderRepository.CurrencyRateByCurrencyRateID(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidCustomerByCustomerID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesOrderHeaderRepository.CustomerByCustomerID(id);

			return record != null;
		}

		protected async Task<bool> BeValidSalesPersonBySalesPersonID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesOrderHeaderRepository.SalesPersonBySalesPersonID(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidSalesTerritoryByTerritoryID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesOrderHeaderRepository.SalesTerritoryByTerritoryID(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeUniqueByRowguid(ApiSalesOrderHeaderServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesOrderHeader record = await this.SalesOrderHeaderRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.SalesOrderID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueBySalesOrderNumber(ApiSalesOrderHeaderServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesOrderHeader record = await this.SalesOrderHeaderRepository.BySalesOrderNumber(model.SalesOrderNumber);

			if (record == null || (this.existingRecordId != default(int) && record.SalesOrderID == this.existingRecordId))
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
    <Hash>4d4824f526ae62be4b09f547c2ef71a3</Hash>
</Codenesium>*/