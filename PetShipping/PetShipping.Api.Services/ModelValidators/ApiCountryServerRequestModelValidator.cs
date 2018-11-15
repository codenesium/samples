using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiCountryServerRequestModelValidator : AbstractApiCountryServerRequestModelValidator, IApiCountryServerRequestModelValidator
	{
		public ApiCountryServerRequestModelValidator(ICountryRepository countryRepository)
			: base(countryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCountryServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryServerRequestModel model)
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
    <Hash>5a3350dd1844b56e0756a83ec5a8a952</Hash>
</Codenesium>*/