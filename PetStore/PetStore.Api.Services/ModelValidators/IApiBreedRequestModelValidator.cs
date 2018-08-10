using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiBreedRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBreedRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ffe866fa73a4757ae685d1876ef5ed40</Hash>
</Codenesium>*/