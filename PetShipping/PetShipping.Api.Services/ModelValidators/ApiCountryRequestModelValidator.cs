using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiCountryRequestModelValidator : AbstractApiCountryRequestModelValidator, IApiCountryRequestModelValidator
	{
		public ApiCountryRequestModelValidator(ICountryRepository countryRepository)
			: base(countryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>e71b0a2a2e634a782846fd5fedac359a</Hash>
</Codenesium>*/