using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractPasswordModelValidator: AbstractValidator<PasswordModel>
	{
		public new ValidationResult Validate(PasswordModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PasswordModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void PasswordHashRules()
		{
			RuleFor(x => x.PasswordHash).NotNull();
			RuleFor(x => x.PasswordHash).Length(0,128);
		}

		public virtual void PasswordSaltRules()
		{
			RuleFor(x => x.PasswordSalt).NotNull();
			RuleFor(x => x.PasswordSalt).Length(0,10);
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
    <Hash>67e73909dc9201083a92b859607fba58</Hash>
</Codenesium>*/