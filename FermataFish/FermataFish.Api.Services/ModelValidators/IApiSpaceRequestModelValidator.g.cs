using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiSpaceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>819fdde9f571db6b31272f108d58dc04</Hash>
</Codenesium>*/