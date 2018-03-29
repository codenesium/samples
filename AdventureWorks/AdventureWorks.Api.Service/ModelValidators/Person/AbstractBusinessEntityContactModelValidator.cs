using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractBusinessEntityContactModelValidator: AbstractValidator<BusinessEntityContactModel>
	{
		public new ValidationResult Validate(BusinessEntityContactModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(BusinessEntityContactModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IBusinessEntityRepository BusinessEntityRepository {get; set;}
		public IPersonRepository PersonRepository {get; set;}
		public IContactTypeRepository ContactTypeRepository {get; set;}
		public virtual void PersonIDRules()
		{
			RuleFor(x => x.PersonID).NotNull();
			RuleFor(x => x.PersonID).Must(BeValidPerson).When(x => x ?.PersonID != null).WithMessage("Invalid reference");
		}

		public virtual void ContactTypeIDRules()
		{
			RuleFor(x => x.ContactTypeID).NotNull();
			RuleFor(x => x.ContactTypeID).Must(BeValidContactType).When(x => x ?.ContactTypeID != null).WithMessage("Invalid reference");
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidBusinessEntity(int id)
		{
			Response response = new Response();

			this.BusinessEntityRepository.GetById(id,response);
			return response.BusinessEntities.Count > 0;
		}

		public bool BeValidPerson(int id)
		{
			Response response = new Response();

			this.PersonRepository.GetById(id,response);
			return response.People.Count > 0;
		}

		public bool BeValidContactType(int id)
		{
			Response response = new Response();

			this.ContactTypeRepository.GetById(id,response);
			return response.ContactTypes.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>277995d2e1edf9d55a528bfe59de4be6</Hash>
</Codenesium>*/