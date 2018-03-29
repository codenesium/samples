using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractAddressTypeModelValidator: AbstractValidator<AddressTypeModel>
	{
		public new ValidationResult Validate(AddressTypeModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(AddressTypeModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
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
    <Hash>30372673a7e65c93fb80d5d49b99bfb7</Hash>
</Codenesium>*/