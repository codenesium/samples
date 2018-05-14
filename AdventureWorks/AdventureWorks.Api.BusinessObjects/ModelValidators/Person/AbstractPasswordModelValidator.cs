using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiPasswordModelValidator: AbstractValidator<ApiPasswordModel>
	{
		public new ValidationResult Validate(ApiPasswordModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPasswordModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PasswordHashRules()
		{
			this.RuleFor(x => x.PasswordHash).NotNull();
			this.RuleFor(x => x.PasswordHash).Length(0, 128);
		}

		public virtual void PasswordSaltRules()
		{
			this.RuleFor(x => x.PasswordSalt).NotNull();
			this.RuleFor(x => x.PasswordSalt).Length(0, 10);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>de39258d23b0b09801fbd70c03e37d6d</Hash>
</Codenesium>*/