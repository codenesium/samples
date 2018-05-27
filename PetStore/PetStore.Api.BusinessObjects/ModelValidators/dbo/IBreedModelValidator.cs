using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiBreedRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBreedRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>76e6f184410ee78127ea6bb7081f1bbc</Hash>
</Codenesium>*/