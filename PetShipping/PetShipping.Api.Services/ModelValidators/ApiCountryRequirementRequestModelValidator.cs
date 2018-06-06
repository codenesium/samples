using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class ApiCountryRequirementRequestModelValidator: AbstractApiCountryRequirementRequestModelValidator, IApiCountryRequirementRequestModelValidator
	{
		public ApiCountryRequirementRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRequirementRequestModel model)
		{
			this.CountryIdRules();
			this.DetailsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequirementRequestModel model)
		{
			this.CountryIdRules();
			this.DetailsRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>cfa211c172312d332b572d56cb0f2a9b</Hash>
</Codenesium>*/