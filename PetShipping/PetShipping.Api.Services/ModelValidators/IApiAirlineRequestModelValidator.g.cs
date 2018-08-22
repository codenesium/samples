using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiAirlineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirlineRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>65124553470e9fd61666bea297a5ac87</Hash>
</Codenesium>*/