using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiCountryRegionCurrencyModelValidator: AbstractApiCountryRegionCurrencyModelValidator, IApiCountryRegionCurrencyModelValidator
	{
		public ApiCountryRegionCurrencyModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionCurrencyModel model)
		{
			this.CurrencyCodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionCurrencyModel model)
		{
			this.CurrencyCodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>bd1ecfe7a8de506f21b696102e8a49dc</Hash>
</Codenesium>*/