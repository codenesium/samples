using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiBreedRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBreedRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dd48f6a334eeff5d0fc03c1600111d4f</Hash>
</Codenesium>*/