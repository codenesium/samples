using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiPetServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPetServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8d502a552524f6a5c7016c38806eb18e</Hash>
</Codenesium>*/