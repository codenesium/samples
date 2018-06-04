using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.Services
{
	public interface IApiSpeciesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpeciesRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b4af652fbf08a16f3150e11a982398cb</Hash>
</Codenesium>*/