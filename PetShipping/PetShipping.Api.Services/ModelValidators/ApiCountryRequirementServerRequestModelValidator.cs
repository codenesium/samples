using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiCountryRequirementServerRequestModelValidator : AbstractApiCountryRequirementServerRequestModelValidator, IApiCountryRequirementServerRequestModelValidator
	{
		public ApiCountryRequirementServerRequestModelValidator(ICountryRequirementRepository countryRequirementRepository)
			: base(countryRequirementRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRequirementServerRequestModel model)
		{
			this.CountryIdRules();
			this.DetailRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequirementServerRequestModel model)
		{
			this.CountryIdRules();
			this.DetailRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>af597b4397a5fbd14386488e68a60c93</Hash>
</Codenesium>*/