using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiBreedRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBreedRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>71e08d592921edf83e149b0253753e60</Hash>
</Codenesium>*/