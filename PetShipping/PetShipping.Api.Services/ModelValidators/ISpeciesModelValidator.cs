using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiSpeciesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpeciesRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ac3d4b7b457b35829a19b7bfe68716b8</Hash>
</Codenesium>*/