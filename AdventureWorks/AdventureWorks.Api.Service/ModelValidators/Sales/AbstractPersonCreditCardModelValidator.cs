using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractPersonCreditCardModelValidator: AbstractValidator<PersonCreditCardModel>
	{
		public new ValidationResult Validate(PersonCreditCardModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PersonCreditCardModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void CreditCardIDRules()
		{
			RuleFor(x => x.CreditCardID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>3bdc2eb17973d30751d10ac3cbf5e027</Hash>
</Codenesium>*/