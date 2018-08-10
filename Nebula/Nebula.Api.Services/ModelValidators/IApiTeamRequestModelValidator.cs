using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiTeamRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeamRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeamRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1cc94196ddd81ffb370a0c9f27f381dc</Hash>
</Codenesium>*/