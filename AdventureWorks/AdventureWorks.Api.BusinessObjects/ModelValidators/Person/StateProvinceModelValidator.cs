using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class StateProvinceModelValidator: AbstractStateProvinceModelValidator, IStateProvinceModelValidator
	{
		public StateProvinceModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(StateProvinceModel model)
		{
			this.StateProvinceCodeRules();
			this.CountryRegionCodeRules();
			this.IsOnlyStateProvinceFlagRules();
			this.NameRules();
			this.TerritoryIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, StateProvinceModel model)
		{
			this.StateProvinceCodeRules();
			this.CountryRegionCodeRules();
			this.IsOnlyStateProvinceFlagRules();
			this.NameRules();
			this.TerritoryIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>2e6ccd79e3ac407df631229e62209950</Hash>
</Codenesium>*/