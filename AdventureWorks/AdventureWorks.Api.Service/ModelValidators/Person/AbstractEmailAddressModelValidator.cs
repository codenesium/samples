using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractEmailAddressModelValidator: AbstractValidator<EmailAddressModel>
	{
		public new ValidationResult Validate(EmailAddressModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(EmailAddressModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void EmailAddressIDRules()
		{
			RuleFor(x => x.EmailAddressID).NotNull();
		}

		public virtual void EmailAddressRules()
		{
			RuleFor(x => x.EmailAddress).Length(0,50);
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
    <Hash>2ef2131b32088b826b74bef4cf5d21e9</Hash>
</Codenesium>*/