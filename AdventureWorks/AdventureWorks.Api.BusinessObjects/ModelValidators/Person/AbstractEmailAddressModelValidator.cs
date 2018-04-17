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
		public virtual void EmailAddressIDRules()
		{
			this.RuleFor(x => x.EmailAddressID).NotNull();
		}

		public virtual void EmailAddress1Rules()
		{
			this.RuleFor(x => x.EmailAddress1).Length(0, 50);
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
    <Hash>225dccb512594f80d7940b4db521a3c1</Hash>
</Codenesium>*/