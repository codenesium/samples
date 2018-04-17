using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public IPersonRepository PersonRepository { get; set; }
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

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidPerson(int id)
		{
			return this.PersonRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>cf0547b42d3a81e18b1f38568612dfea</Hash>
</Codenesium>*/