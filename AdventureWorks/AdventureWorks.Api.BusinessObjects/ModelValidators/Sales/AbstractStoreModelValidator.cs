using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiStoreModelValidator: AbstractValidator<ApiStoreModel>
	{
		public new ValidationResult Validate(ApiStoreModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiStoreModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISalesPersonRepository SalesPersonRepository { get; set; }
		public virtual void DemographicsRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SalesPersonIDRules()
		{
			this.RuleFor(x => x.SalesPersonID).Must(this.BeValidSalesPerson).When(x => x ?.SalesPersonID != null).WithMessage("Invalid reference");
		}

		private bool BeValidSalesPerson(Nullable<int> id)
		{
			return this.SalesPersonRepository.Get(id.GetValueOrDefault()) != null;
		}
	}
}

/*<Codenesium>
    <Hash>fd35b6ee4c1190438294f869c5be2b2a</Hash>
</Codenesium>*/