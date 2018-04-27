using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public IPersonRepository PersonRepository { get; set; }
		public virtual void EmailAddress1Rules()
		{
			this.RuleFor(x => x.EmailAddress1).Length(0, 50);
		}

		public virtual void EmailAddressIDRules()
		{
			this.RuleFor(x => x.EmailAddressID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		private bool BeValidPerson(int id)
		{
			return this.PersonRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>8b3db631d7fe6d9c11c7152fa78c17c7</Hash>
</Codenesium>*/