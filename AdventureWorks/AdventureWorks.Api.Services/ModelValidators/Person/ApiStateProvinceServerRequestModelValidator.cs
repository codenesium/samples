using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiStateProvinceServerRequestModelValidator : AbstractApiStateProvinceServerRequestModelValidator, IApiStateProvinceServerRequestModelValidator
	{
		public ApiStateProvinceServerRequestModelValidator(IStateProvinceRepository stateProvinceRepository)
			: base(stateProvinceRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceServerRequestModel model)
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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>2c55b843da303cb4142bdebe0c5925c9</Hash>
</Codenesium>*/