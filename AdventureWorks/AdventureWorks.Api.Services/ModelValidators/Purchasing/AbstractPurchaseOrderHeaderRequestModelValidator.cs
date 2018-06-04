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
	public abstract class AbstractApiPurchaseOrderHeaderRequestModelValidator: AbstractValidator<ApiPurchaseOrderHeaderRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiPurchaseOrderHeaderRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPurchaseOrderHeaderRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

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
		}
	}
}

/*<Codenesium>
    <Hash>c145e64c401f0389bfe30a195fbc39bf</Hash>
</Codenesium>*/