using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class CountryModelValidator: AbstractCountryModelValidator, ICountryModelValidator
	{
		public CountryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(CountryModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, CountryModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>6f8cb50b7b869ba294131cc7d1f6c776</Hash>
</Codenesium>*/