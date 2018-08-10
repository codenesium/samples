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
    <Hash>e9a0b8a4e4b97cf65b423dec20da976c</Hash>
</Codenesium>*/