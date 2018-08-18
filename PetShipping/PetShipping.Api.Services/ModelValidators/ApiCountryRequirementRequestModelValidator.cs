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
    <Hash>0a248887e6f728f9d98488c2ad9b48f2</Hash>
</Codenesium>*/