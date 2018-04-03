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

		public virtual void AddressIDRules()
		{
			RuleFor(x => x.AddressID).NotNull();
		}

		public virtual void AddressTypeIDRules()
		{
			RuleFor(x => x.AddressTypeID).NotNull();
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>451653698d73bb92b94297d518dd139c</Hash>
</Codenesium>*/