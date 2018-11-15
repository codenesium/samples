using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
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
    <Hash>0a320ae8ff07f267b8e3962687a84176</Hash>
</Codenesium>*/