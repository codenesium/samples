using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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

		public virtual void PersonIDRules()
		{
			RuleFor(x => x.PersonID).NotNull();
		}

		public virtual void ContactTypeIDRules()
		{
			RuleFor(x => x.ContactTypeID).NotNull();
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>ec9e4c86de9ce23b0dab10059b3261ed</Hash>
</Codenesium>*/