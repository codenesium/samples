using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiSpeciesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpeciesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>18253de8fb2b64e20af44c53a4ae082b</Hash>
</Codenesium>*/