using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiBreedServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBreedServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>757f1d34e76ab88ed89926c7e444ee09</Hash>
</Codenesium>*/