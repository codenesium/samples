using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiAirlineServerRequestModelValidator : AbstractApiAirlineServerRequestModelValidator, IApiAirlineServerRequestModelValidator
	{
		public ApiAirlineServerRequestModelValidator(IAirlineRepository airlineRepository)
			: base(airlineRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAirlineServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineServerRequestModel model)
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
    <Hash>038eb9221eb7ffb95cc5cb0f165e76c0</Hash>
</Codenesium>*/