using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiAirlineRequestModelValidator : AbstractApiAirlineRequestModelValidator, IApiAirlineRequestModelValidator
	{
		public ApiAirlineRequestModelValidator(IAirlineRepository airlineRepository)
			: base(airlineRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAirlineRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineRequestModel model)
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
    <Hash>d4f64869968391ff2f3be0d9c107f99a</Hash>
</Codenesium>*/