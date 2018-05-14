using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiBusinessEntityAddressModelValidator: AbstractValidator<ApiBusinessEntityAddressModel>
	{
		public new ValidationResult Validate(ApiBusinessEntityAddressModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityAddressModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void AddressIDRules()
		{
			this.RuleFor(x => x.AddressID).NotNull();
		}

		public virtual void AddressTypeIDRules()
		{
			this.RuleFor(x => x.AddressTypeID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>786fe7e0590ef0bb79641982bc276021</Hash>
</Codenesium>*/