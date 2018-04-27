using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public IBusinessEntityRepository BusinessEntityRepository { get; set; }
		public IContactTypeRepository ContactTypeRepository { get; set; }
		public IPersonRepository PersonRepository { get; set; }
		public virtual void ContactTypeIDRules()
		{
			this.RuleFor(x => x.ContactTypeID).NotNull();
			this.RuleFor(x => x.ContactTypeID).Must(this.BeValidContactType).When(x => x ?.ContactTypeID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PersonIDRules()
		{
			this.RuleFor(x => x.PersonID).NotNull();
			this.RuleFor(x => x.PersonID).Must(this.BeValidPerson).When(x => x ?.PersonID != null).WithMessage("Invalid reference");
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		private bool BeValidBusinessEntity(int id)
		{
			return this.BusinessEntityRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidContactType(int id)
		{
			return this.ContactTypeRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidPerson(int id)
		{
			return this.PersonRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>a596a166bc64616544e298dece982d31</Hash>
</Codenesium>*/