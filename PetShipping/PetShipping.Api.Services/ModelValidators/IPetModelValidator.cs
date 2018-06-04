using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiPetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5e5c0f8541c0011862ad7aa3ce876764</Hash>
</Codenesium>*/