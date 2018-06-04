using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCountryRegionCurrencyRequestModelValidator: AbstractApiCountryRegionCurrencyRequestModelValidator, IApiCountryRegionCurrencyRequestModelValidator
	{
		public ApiCountryRegionCurrencyRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionCurrencyRequestModel model)
		{
			this.CurrencyCodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionCurrencyRequestModel model)
		{
			this.CurrencyCodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>ef3782f230d8aac21eeca7bc5788e0ac</Hash>
</Codenesium>*/