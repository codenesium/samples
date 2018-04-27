using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public IBusinessEntityRepository BusinessEntityRepository { get; set; }
		public virtual void AdditionalContactInfoRules()
		{                       }

		public virtual void DemographicsRules()
		{                       }

		public virtual void EmailPromotionRules()
		{
			this.RuleFor(x => x.EmailPromotion).NotNull();
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull();
			this.RuleFor(x => x.FirstName).Length(0, 50);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull();
			this.RuleFor(x => x.LastName).Length(0, 50);
		}

		public virtual void MiddleNameRules()
		{
			this.RuleFor(x => x.MiddleName).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameStyleRules()
		{
			this.RuleFor(x => x.NameStyle).NotNull();
		}

		public virtual void PersonTypeRules()
		{
			this.RuleFor(x => x.PersonType).NotNull();
			this.RuleFor(x => x.PersonType).Length(0, 2);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SuffixRules()
		{
			this.RuleFor(x => x.Suffix).Length(0, 10);
		}

		public virtual void TitleRules()
		{
			this.RuleFor(x => x.Title).Length(0, 8);
		}

		private bool BeValidBusinessEntity(int id)
		{
			return this.BusinessEntityRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>67097c739bae47826bb1a693513e6465</Hash>
</Codenesium>*/