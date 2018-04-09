using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractBusinessEntityAddressModelValidator: AbstractValidator<BusinessEntityAddressModel>
	{
		public new ValidationResult Validate(BusinessEntityAddressModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(BusinessEntityAddressModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IBusinessEntityRepository BusinessEntityRepository {get; set;}
		public IAddressRepository AddressRepository {get; set;}
		public IAddressTypeRepository AddressTypeRepository {get; set;}
		public virtual void AddressIDRules()
		{
			RuleFor(x => x.AddressID).NotNull();
			RuleFor(x => x.AddressID).Must(BeValidAddress).When(x => x ?.AddressID != null).WithMessage("Invalid reference");
		}

		public virtual void AddressTypeIDRules()
		{
			RuleFor(x => x.AddressTypeID).NotNull();
			RuleFor(x => x.AddressTypeID).Must(BeValidAddressType).When(x => x ?.AddressTypeID != null).WithMessage("Invalid reference");
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

		private bool BeValidAddress(int id)
		{
			return this.AddressRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidAddressType(int id)
		{
			return this.AddressTypeRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>41c64179c90f54501dd7fd1f3ba17680</Hash>
</Codenesium>*/