using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.Services
{
	public interface IApiPetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7b72289957147cf322ee20814116e22b</Hash>
</Codenesium>*/