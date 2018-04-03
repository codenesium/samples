using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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

		public virtual void RevisionNumberRules()
		{
			RuleFor(x => x.RevisionNumber).NotNull();
		}

		public virtual void StatusRules()
		{
			RuleFor(x => x.Status).NotNull();
		}

		public virtual void EmployeeIDRules()
		{
			RuleFor(x => x.EmployeeID).NotNull();
		}

		public virtual void VendorIDRules()
		{
			RuleFor(x => x.VendorID).NotNull();
		}

		public virtual void ShipMethodIDRules()
		{
			RuleFor(x => x.ShipMethodID).NotNull();
		}

		public virtual void OrderDateRules()
		{
			RuleFor(x => x.OrderDate).NotNull();
		}

		public virtual void ShipDateRules()
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

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>c6f255f6f9a026d7e0754238f2d04d21</Hash>
</Codenesium>*/