using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractStateProvinceModelValidator: AbstractValidator<StateProvinceModel>
	{
		public new ValidationResult Validate(StateProvinceModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(StateProvinceModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void StateProvinceCodeRules()
		{
			RuleFor(x => x.StateProvinceCode).NotNull();
			RuleFor(x => x.StateProvinceCode).Length(0,3);
		}

		public virtual void CountryRegionCodeRules()
		{
			RuleFor(x => x.CountryRegionCode).NotNull();
			RuleFor(x => x.CountryRegionCode).Length(0,3);
		}

		public virtual void IsOnlyStateProvinceFlagRules()
		{
			RuleFor(x => x.IsOnlyStateProvinceFlag).NotNull();
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void TerritoryIDRules()
		{
			RuleFor(x => x.TerritoryID).NotNull();
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
    <Hash>84b7767f8445fe5faef2575982899cc6</Hash>
</Codenesium>*/