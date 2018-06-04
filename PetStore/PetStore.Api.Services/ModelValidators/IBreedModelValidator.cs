using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.Services
{
	public interface IApiBreedRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBreedRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d657a491fd811795fee320089ca75e5f</Hash>
</Codenesium>*/