using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiPetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>34be44511cf3f1a0174e8fb0ffd6e144</Hash>
</Codenesium>*/