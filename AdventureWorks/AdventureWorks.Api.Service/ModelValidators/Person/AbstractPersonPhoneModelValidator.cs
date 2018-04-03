using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractPersonPhoneModelValidator: AbstractValidator<PersonPhoneModel>
	{
		public new ValidationResult Validate(PersonPhoneModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PersonPhoneModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void PhoneNumberRules()
		{
			RuleFor(x => x.PhoneNumber).NotNull();
			RuleFor(x => x.PhoneNumber).Length(0,25);
		}

		public virtual void PhoneNumberTypeIDRules()
		{
			RuleFor(x => x.PhoneNumberTypeID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>e449b20c75e34dcee80094af78a1bda9</Hash>
</Codenesium>*/