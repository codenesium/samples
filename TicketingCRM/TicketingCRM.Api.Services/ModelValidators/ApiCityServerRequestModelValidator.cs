using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiCityServerRequestModelValidator : AbstractApiCityServerRequestModelValidator, IApiCityServerRequestModelValidator
	{
		public ApiCityServerRequestModelValidator(ICityRepository cityRepository)
			: base(cityRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCityServerRequestModel model)
		{
			this.NameRules();
			this.ProvinceIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCityServerRequestModel model)
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
    <Hash>5d77abc0529ce8a995b3e5767bc39b23</Hash>
</Codenesium>*/