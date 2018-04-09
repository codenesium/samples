using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractPersonModelValidator: AbstractValidator<PersonModel>
	{
		public new ValidationResult Validate(PersonModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PersonModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IBusinessEntityRepository BusinessEntityRepository {get; set;}
		public virtual void PersonTypeRules()
		{
			RuleFor(x => x.PersonType).NotNull();
			RuleFor(x => x.PersonType).Length(0,2);
		}

		public virtual void NameStyleRules()
		{
			RuleFor(x => x.NameStyle).NotNull();
		}

		public virtual void TitleRules()
		{
			RuleFor(x => x.Title).Length(0,8);
		}

		public virtual void FirstNameRules()
		{
			RuleFor(x => x.FirstName).NotNull();
			RuleFor(x => x.FirstName).Length(0,50);
		}

		public virtual void MiddleNameRules()
		{
			RuleFor(x => x.MiddleName).Length(0,50);
		}

		public virtual void LastNameRules()
		{
			RuleFor(x => x.LastName).NotNull();
			RuleFor(x => x.LastName).Length(0,50);
		}

		public virtual void SuffixRules()
		{
			RuleFor(x => x.Suffix).Length(0,10);
		}

		public virtual void EmailPromotionRules()
		{
			RuleFor(x => x.EmailPromotion).NotNull();
		}

		public virtual void AdditionalContactInfoRules()
		{                       }

		public virtual void DemographicsRules()
		{                       }

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
	}
}

/*<Codenesium>
    <Hash>12355084ac610a9e9996a77f6133508c</Hash>
</Codenesium>*/