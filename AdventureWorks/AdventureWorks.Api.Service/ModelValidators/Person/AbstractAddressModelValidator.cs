using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractAddressModelValidator: AbstractValidator<AddressModel>
	{
		public new ValidationResult Validate(AddressModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(AddressModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void AddressLine1Rules()
		{
			RuleFor(x => x.AddressLine1).NotNull();
			RuleFor(x => x.AddressLine1).Length(0,60);
		}

		public virtual void AddressLine2Rules()
		{
			RuleFor(x => x.AddressLine2).Length(0,60);
		}

		public virtual void CityRules()
		{
			RuleFor(x => x.City).NotNull();
			RuleFor(x => x.City).Length(0,30);
		}

		public virtual void StateProvinceIDRules()
		{
			RuleFor(x => x.StateProvinceID).NotNull();
		}

		public virtual void PostalCodeRules()
		{
			RuleFor(x => x.PostalCode).NotNull();
			RuleFor(x => x.PostalCode).Length(0,15);
		}

		public virtual void SpatialLocationRules()
		{                       }

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
    <Hash>900a38d9d2d7834976989bc699173a2e</Hash>
</Codenesium>*/