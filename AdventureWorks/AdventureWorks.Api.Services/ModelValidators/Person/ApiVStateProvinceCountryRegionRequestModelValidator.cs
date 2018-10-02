using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiVStateProvinceCountryRegionRequestModelValidator : AbstractApiVStateProvinceCountryRegionRequestModelValidator, IApiVStateProvinceCountryRegionRequestModelValidator
	{
		public ApiVStateProvinceCountryRegionRequestModelValidator(IVStateProvinceCountryRegionRepository vStateProvinceCountryRegionRepository)
			: base(vStateProvinceCountryRegionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVStateProvinceCountryRegionRequestModel model)
		{
			this.CountryRegionCodeRules();
			this.CountryRegionNameRules();
			this.IsOnlyStateProvinceFlagRules();
			this.StateProvinceCodeRules();
			this.StateProvinceNameRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVStateProvinceCountryRegionRequestModel model)
		{
			this.CountryRegionCodeRules();
			this.CountryRegionNameRules();
			this.IsOnlyStateProvinceFlagRules();
			this.StateProvinceCodeRules();
			this.StateProvinceNameRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>4ed703e908fc3484291ff363b6bbf4c3</Hash>
</Codenesium>*/