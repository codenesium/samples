using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiStateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d4e5be7b44165ef4d98b3c0ed5b72789</Hash>
</Codenesium>*/