using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiVendorModelValidator: AbstractValidator<ApiVendorModel>
	{
		public new ValidationResult Validate(ApiVendorModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiVendorModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IVendorRepository VendorRepository { get; set; }
		public virtual void AccountNumberRules()
		{
			this.RuleFor(x => x.AccountNumber).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetAccountNumber).When(x => x ?.AccountNumber != null).WithMessage("Violates unique constraint");
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

		private bool BeUniqueGetAccountNumber(ApiVendorModel model)
		{
			return this.VendorRepository.GetAccountNumber(model.AccountNumber) != null;
		}
	}
}

/*<Codenesium>
    <Hash>1a4cfa0a00f1238def47f80d0ff5c934</Hash>
</Codenesium>*/