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

		public bool BeValidBusinessEntity(int id)
		{
			Response response = new Response();

			this.BusinessEntityRepository.GetById(id,response);
			return response.BusinessEntities.Count > 0;
		}

		public bool BeValidAddress(int id)
		{
			Response response = new Response();

			this.AddressRepository.GetById(id,response);
			return response.Addresses.Count > 0;
		}

		public bool BeValidAddressType(int id)
		{
			Response response = new Response();

			this.AddressTypeRepository.GetById(id,response);
			return response.AddressTypes.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>7e256d265dfa40d82b54a944b7282a12</Hash>
</Codenesium>*/