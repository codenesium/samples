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

		public IPersonRepository PersonRepository {get; set;}
		public IPhoneNumberTypeRepository PhoneNumberTypeRepository {get; set;}
		public virtual void PhoneNumberRules()
		{
			RuleFor(x => x.PhoneNumber).NotNull();
			RuleFor(x => x.PhoneNumber).Length(0,25);
		}

		public virtual void PhoneNumberTypeIDRules()
		{
			RuleFor(x => x.PhoneNumberTypeID).NotNull();
			RuleFor(x => x.PhoneNumberTypeID).Must(BeValidPhoneNumberType).When(x => x ?.PhoneNumberTypeID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidPerson(int id)
		{
			Response response = new Response();

			this.PersonRepository.GetById(id,response);
			return response.People.Count > 0;
		}

		public bool BeValidPhoneNumberType(int id)
		{
			Response response = new Response();

			this.PhoneNumberTypeRepository.GetById(id,response);
			return response.PhoneNumberTypes.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>e28756b981fa385340a40e79c3eb5762</Hash>
</Codenesium>*/