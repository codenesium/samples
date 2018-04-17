using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public IPersonRepository PersonRepository { get; set; }
		public IPhoneNumberTypeRepository PhoneNumberTypeRepository { get; set; }
		public virtual void PhoneNumberRules()
		{
			this.RuleFor(x => x.PhoneNumber).NotNull();
			this.RuleFor(x => x.PhoneNumber).Length(0, 25);
		}

		public virtual void PhoneNumberTypeIDRules()
		{
			this.RuleFor(x => x.PhoneNumberTypeID).NotNull();
			this.RuleFor(x => x.PhoneNumberTypeID).Must(this.BeValidPhoneNumberType).When(x => x ?.PhoneNumberTypeID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidPerson(int id)
		{
			return this.PersonRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidPhoneNumberType(int id)
		{
			return this.PhoneNumberTypeRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>b88296c8921e9f92f3a2fb32b5a41afe</Hash>
</Codenesium>*/