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
    <Hash>6ef2ea813ea3e57a5e250e59230a9450</Hash>
</Codenesium>*/