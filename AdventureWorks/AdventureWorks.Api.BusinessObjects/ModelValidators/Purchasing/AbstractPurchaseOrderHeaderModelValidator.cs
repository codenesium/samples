using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractPurchaseOrderHeaderModelValidator: AbstractValidator<PurchaseOrderHeaderModel>
	{
		public new ValidationResult Validate(PurchaseOrderHeaderModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PurchaseOrderHeaderModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IShipMethodRepository ShipMethodRepository { get; set; }
		public IVendorRepository VendorRepository { get; set; }
		public virtual void EmployeeIDRules()
		{
			this.RuleFor(x => x.EmployeeID).NotNull();
		}

		public virtual void FreightRules()
		{
			this.RuleFor(x => x.Freight).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void OrderDateRules()
		{
			this.RuleFor(x => x.OrderDate).NotNull();
		}

		public virtual void RevisionNumberRules()
		{
			this.RuleFor(x => x.RevisionNumber).NotNull();
		}

		public virtual void ShipDateRules()
		{                       }

		public virtual void ShipMethodIDRules()
		{
			this.RuleFor(x => x.ShipMethodID).NotNull();
			this.RuleFor(x => x.ShipMethodID).Must(this.BeValidShipMethod).When(x => x ?.ShipMethodID != null).WithMessage("Invalid reference");
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

		public virtual void TotalDueRules()
		{
			this.RuleFor(x => x.TotalDue).NotNull();
		}

		public virtual void VendorIDRules()
		{
			this.RuleFor(x => x.VendorID).NotNull();
			this.RuleFor(x => x.VendorID).Must(this.BeValidVendor).When(x => x ?.VendorID != null).WithMessage("Invalid reference");
		}

		private bool BeValidShipMethod(int id)
		{
			return this.ShipMethodRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidVendor(int id)
		{
			return this.VendorRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>d2fa3a661a8e449e435f8443b30c1edb</Hash>
</Codenesium>*/