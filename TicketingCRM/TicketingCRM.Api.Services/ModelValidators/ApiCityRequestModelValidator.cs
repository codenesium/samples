using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiCityRequestModelValidator : AbstractApiCityRequestModelValidator, IApiCityRequestModelValidator
	{
		public ApiCityRequestModelValidator(ICityRepository cityRepository)
			: base(cityRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCityRequestModel model)
		{
			this.NameRules();
			this.ProvinceIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCityRequestModel model)
		{
			this.NameRules();
			this.ProvinceIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>56a940fd55c9c4ff69c7dc9927ab1513</Hash>
</Codenesium>*/