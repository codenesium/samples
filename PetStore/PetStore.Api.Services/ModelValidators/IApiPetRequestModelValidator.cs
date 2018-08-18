using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiPetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ac6e8a7b8ec71daa9f01bbbd017db187</Hash>
</Codenesium>*/