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
			this.NameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, CountryRegionModel model)
		{
			this.NameRules();
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
    <Hash>1455d6c29b932703ae0664410d0ca649</Hash>
</Codenesium>*/