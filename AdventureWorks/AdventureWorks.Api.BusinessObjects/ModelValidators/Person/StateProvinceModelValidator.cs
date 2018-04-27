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
			this.CountryRegionCodeRules();
			this.IsOnlyStateProvinceFlagRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.StateProvinceCodeRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, StateProvinceModel model)
		{
			this.CountryRegionCodeRules();
			this.IsOnlyStateProvinceFlagRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.StateProvinceCodeRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>63ad2b5e640ce2e5fd5f668f9d26a21b</Hash>
</Codenesium>*/