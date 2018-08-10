using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiStudioRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudioRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d7ebb7b51ca280379ff940b5fd01b1e9</Hash>
</Codenesium>*/