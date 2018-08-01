using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCountryRegionCurrencyRequestModelValidator : AbstractApiCountryRegionCurrencyRequestModelValidator, IApiCountryRegionCurrencyRequestModelValidator
	{
		public ApiCountryRegionCurrencyRequestModelValidator(ICountryRegionCurrencyRepository countryRegionCurrencyRepository)
			: base(countryRegionCurrencyRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>dc306240badd9d22c85a0534ce59cfc5</Hash>
</Codenesium>*/