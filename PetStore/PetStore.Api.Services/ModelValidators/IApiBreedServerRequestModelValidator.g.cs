using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiBreedServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBreedServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>49c98ffb93b8316653db1a7b9bc32abd</Hash>
</Codenesium>*/