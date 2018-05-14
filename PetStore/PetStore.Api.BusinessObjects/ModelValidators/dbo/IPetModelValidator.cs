using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiPetModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPetModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e044aab775242c1716b6c1df9127a3b7</Hash>
</Codenesium>*/