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

		public IPersonRepository PersonRepository {get; set;}
		public ICreditCardRepository CreditCardRepository {get; set;}
		public virtual void CreditCardIDRules()
		{
			RuleFor(x => x.CreditCardID).NotNull();
			RuleFor(x => x.CreditCardID).Must(BeValidCreditCard).When(x => x ?.CreditCardID != null).WithMessage("Invalid reference");
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

		public bool BeValidCreditCard(int id)
		{
			Response response = new Response();

			this.CreditCardRepository.GetById(id,response);
			return response.CreditCards.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>948de5ef3e1e7189bfd9e1859c0bd9cb</Hash>
</Codenesium>*/