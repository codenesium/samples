using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiStateProvinceRequestModelValidator : AbstractApiStateProvinceRequestModelValidator, IApiStateProvinceRequestModelValidator
	{
		public ApiStateProvinceRequestModelValidator(IStateProvinceRepository stateProvinceRepository)
			: base(stateProvinceRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>a34a07dd9ee1219c4dc2b2ef92501fd2</Hash>
</Codenesium>*/