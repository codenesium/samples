using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
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
    <Hash>e24d2cb7bcfe1a7e6ff6a9a9750bc606</Hash>
</Codenesium>*/