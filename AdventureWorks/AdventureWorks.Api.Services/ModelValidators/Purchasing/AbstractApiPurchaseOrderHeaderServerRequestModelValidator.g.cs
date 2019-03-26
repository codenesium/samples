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
	public abstract class AbstractApiPurchaseOrderHeaderServerRequestModelValidator : AbstractValidator<ApiPurchaseOrderHeaderServerRequestModel>
	{
		private int existingRecordId;

		protected IPurchaseOrderHeaderRepository PurchaseOrderHeaderRepository { get; private set; }

		public AbstractApiPurchaseOrderHeaderServerRequestModelValidator(IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository)
		{
			this.PurchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPurchaseOrderHeaderServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EmployeeIDRules()
		{
		}

		public virtual void FreightRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void OrderDateRules()
		{
		}

		public virtual void RevisionNumberRules()
		{
		}

		public virtual void ShipDateRules()
		{
		}

		public virtual void ShipMethodIDRules()
		{
			this.RuleFor(x => x.ShipMethodID).MustAsync(this.BeValidShipMethodByShipMethodID).When(x => !x?.ShipMethodID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
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

		public virtual void TotalDueRules()
		{
		}

		public virtual void VendorIDRules()
		{
			this.RuleFor(x => x.VendorID).MustAsync(this.BeValidVendorByVendorID).When(x => !x?.VendorID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidShipMethodByShipMethodID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PurchaseOrderHeaderRepository.ShipMethodByShipMethodID(id);

			return record != null;
		}

		protected async Task<bool> BeValidVendorByVendorID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PurchaseOrderHeaderRepository.VendorByVendorID(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>0e9ba5486b5de1f1270f2ce4360298ae</Hash>
</Codenesium>*/