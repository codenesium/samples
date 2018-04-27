using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class CountryRegionModelValidator: AbstractCountryRegionModelValidator, ICountryRegionModelValidator
	{
		public CountryRegionModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(CountryRegionModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, CountryRegionModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>a9b5f0acf3412b547e3f6f35a0b0421c</Hash>
</Codenesium>*/