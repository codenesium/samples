using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiStateProvinceModelValidator: AbstractApiStateProvinceModelValidator, IApiStateProvinceModelValidator
	{
		public ApiStateProvinceModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceModel model)
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
    <Hash>29ec2db91b3761a4e2c47807a277f121</Hash>
</Codenesium>*/