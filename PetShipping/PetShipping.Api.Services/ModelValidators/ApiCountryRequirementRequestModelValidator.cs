using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiCountryRequirementRequestModelValidator : AbstractApiCountryRequirementRequestModelValidator, IApiCountryRequirementRequestModelValidator
	{
		public ApiCountryRequirementRequestModelValidator(ICountryRequirementRepository countryRequirementRepository)
			: base(countryRequirementRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>6926a3d0f1e126e4247e3d0f01d7c550</Hash>
</Codenesium>*/