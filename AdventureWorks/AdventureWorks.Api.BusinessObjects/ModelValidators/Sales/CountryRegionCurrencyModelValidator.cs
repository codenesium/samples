using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class CountryRegionCurrencyModelValidator: AbstractCountryRegionCurrencyModelValidator, ICountryRegionCurrencyModelValidator
	{
		public CountryRegionCurrencyModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(CountryRegionCurrencyModel model)
		{
			this.CurrencyCodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, CountryRegionCurrencyModel model)
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
    <Hash>4abf9b0e5c29a7911bcc8dd7196901a0</Hash>
</Codenesium>*/