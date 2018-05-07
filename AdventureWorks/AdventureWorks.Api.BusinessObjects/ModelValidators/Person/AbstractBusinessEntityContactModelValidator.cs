using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractBusinessEntityContactModelValidator: AbstractValidator<BusinessEntityContactModel>
	{
		public new ValidationResult Validate(BusinessEntityContactModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(BusinessEntityContactModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ContactTypeIDRules()
		{
			this.RuleFor(x => x.ContactTypeID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PersonIDRules()
		{
			this.RuleFor(x => x.PersonID).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>ba3bcec83be83cc499b68443e0f55aac</Hash>
</Codenesium>*/