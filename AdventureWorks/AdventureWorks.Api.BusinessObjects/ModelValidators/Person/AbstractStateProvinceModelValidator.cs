using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiStateProvinceModelValidator: AbstractValidator<ApiStateProvinceModel>
	{
		public new ValidationResult Validate(ApiStateProvinceModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiStateProvinceModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void CountryRegionCodeRules()
		{
			this.RuleFor(x => x.CountryRegionCode).NotNull();
			this.RuleFor(x => x.CountryRegionCode).Length(0, 3);
		}

		public virtual void IsOnlyStateProvinceFlagRules()
		{
			this.RuleFor(x => x.IsOnlyStateProvinceFlag).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void StateProvinceCodeRules()
		{
			this.RuleFor(x => x.StateProvinceCode).NotNull();
			this.RuleFor(x => x.StateProvinceCode).Length(0, 3);
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>384791eba408eb524883d674abd73480</Hash>
</Codenesium>*/