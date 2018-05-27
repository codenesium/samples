using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiBusinessEntityAddressRequestModelValidator: AbstractValidator<ApiBusinessEntityAddressRequestModel>
	{
		public new ValidationResult Validate(ApiBusinessEntityAddressRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityAddressRequestModel model)
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
    <Hash>bd3afd50cec173097974ab07f7167c35</Hash>
</Codenesium>*/