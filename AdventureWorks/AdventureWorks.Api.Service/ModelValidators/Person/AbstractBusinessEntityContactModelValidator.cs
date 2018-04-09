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

		private bool BeValidBusinessEntity(int id)
		{
			return this.BusinessEntityRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidPerson(int id)
		{
			return this.PersonRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidContactType(int id)
		{
			return this.ContactTypeRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>0d8206895af9a676e73e3da3dbf14c6f</Hash>
</Codenesium>*/