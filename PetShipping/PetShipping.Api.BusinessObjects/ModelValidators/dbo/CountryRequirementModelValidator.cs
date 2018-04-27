using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class CountryRequirementModelValidator: AbstractCountryRequirementModelValidator, ICountryRequirementModelValidator
	{
		public CountryRequirementModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(CountryRequirementModel model)
		{
			this.CountryIdRules();
			this.DetailsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, CountryRequirementModel model)
		{
			this.CountryIdRules();
			this.DetailsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4bacb02d475bc075e254d366f9805b21</Hash>
</Codenesium>*/