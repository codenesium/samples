using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public IBusinessEntityRepository BusinessEntityRepository { get; set; }
		public IAddressRepository AddressRepository { get; set; }
		public IAddressTypeRepository AddressTypeRepository { get; set; }
		public virtual void AddressIDRules()
		{
			this.RuleFor(x => x.AddressID).NotNull();
			this.RuleFor(x => x.AddressID).Must(this.BeValidAddress).When(x => x ?.AddressID != null).WithMessage("Invalid reference");
		}

		public virtual void AddressTypeIDRules()
		{
			this.RuleFor(x => x.AddressTypeID).NotNull();
			this.RuleFor(x => x.AddressTypeID).Must(this.BeValidAddressType).When(x => x ?.AddressTypeID != null).WithMessage("Invalid reference");
		}

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
    <Hash>831915045c91c352cb815b535fd662d3</Hash>
</Codenesium>*/