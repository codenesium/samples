using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractStoreModelValidator: AbstractValidator<StoreModel>
	{
		public new ValidationResult Validate(StoreModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(StoreModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IBusinessEntityRepository BusinessEntityRepository { get; set; }
		public ISalesPersonRepository SalesPersonRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void SalesPersonIDRules()
		{
			this.RuleFor(x => x.SalesPersonID).Must(this.BeValidSalesPerson).When(x => x ?.SalesPersonID != null).WithMessage("Invalid reference");
		}

		public virtual void DemographicsRules()
		{                       }

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidBusinessEntity(int id)
		{
			return this.BusinessEntityRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidSalesPerson(Nullable<int> id)
		{
			return this.SalesPersonRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}
	}
}

/*<Codenesium>
    <Hash>81485de32eba5422c771489fa7523c40</Hash>
</Codenesium>*/