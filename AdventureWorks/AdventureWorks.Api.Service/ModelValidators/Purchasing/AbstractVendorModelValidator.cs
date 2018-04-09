using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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

		public IBusinessEntityRepository BusinessEntityRepository {get; set;}
		public virtual void AccountNumberRules()
		{
			RuleFor(x => x.AccountNumber).NotNull();
			RuleFor(x => x.AccountNumber).Length(0,15);
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void CreditRatingRules()
		{
			RuleFor(x => x.CreditRating).NotNull();
		}

		public virtual void PreferredVendorStatusRules()
		{
			RuleFor(x => x.PreferredVendorStatus).NotNull();
		}

		public virtual void ActiveFlagRules()
		{
			RuleFor(x => x.ActiveFlag).NotNull();
		}

		public virtual void PurchasingWebServiceURLRules()
		{
			RuleFor(x => x.PurchasingWebServiceURL).Length(0,1024);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidBusinessEntity(int id)
		{
			return this.BusinessEntityRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>ba611c6aa22d683d9f6a5d423718814b</Hash>
</Codenesium>*/