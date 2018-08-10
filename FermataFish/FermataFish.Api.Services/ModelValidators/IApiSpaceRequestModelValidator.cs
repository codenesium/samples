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
    <Hash>f9e1ac65f573395010681fc3a8c6e388</Hash>
</Codenesium>*/