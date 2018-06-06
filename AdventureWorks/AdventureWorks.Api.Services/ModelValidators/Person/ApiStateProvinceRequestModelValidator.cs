using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiStateProvinceRequestModelValidator: AbstractApiStateProvinceRequestModelValidator, IApiStateProvinceRequestModelValidator
	{
		public ApiStateProvinceRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceRequestModel model)
		{
			this.CountryRegionCodeRules();
			this.IsOnlyStateProvinceFlagRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.StateProvinceCodeRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>a2895281cbf10fdfd905e5d51fd15c1b</Hash>
</Codenesium>*/