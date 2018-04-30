using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractVendorModelValidator: AbstractValidator<VendorModel>
	{
		public new ValidationResult Validate(VendorModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(VendorModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void AccountNumberRules()
		{
			this.RuleFor(x => x.AccountNumber).NotNull();
			this.RuleFor(x => x.AccountNumber).Length(0, 15);
		}

		public virtual void ActiveFlagRules()
		{
			this.RuleFor(x => x.ActiveFlag).NotNull();
		}

		public virtual void CreditRatingRules()
		{
			this.RuleFor(x => x.CreditRating).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void PreferredVendorStatusRules()
		{
			this.RuleFor(x => x.PreferredVendorStatus).NotNull();
		}

		public virtual void PurchasingWebServiceURLRules()
		{
			this.RuleFor(x => x.PurchasingWebServiceURL).Length(0, 1024);
		}
	}
}

/*<Codenesium>
    <Hash>07a0b6e8f767ed5a0b894b96bb29a7c3</Hash>
</Codenesium>*/