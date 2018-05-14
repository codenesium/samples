using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiCountryRequirementModelValidator: AbstractApiCountryRequirementModelValidator, IApiCountryRequirementModelValidator
	{
		public ApiCountryRequirementModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRequirementModel model)
		{
			this.CountryIdRules();
			this.DetailsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequirementModel model)
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
    <Hash>1e99ad34d9dd85f096009dcc468c6e29</Hash>
</Codenesium>*/