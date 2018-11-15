using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiTeamServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeamServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeamServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f50bc01e8a0713ccd69c1dda86bb8db2</Hash>
</Codenesium>*/