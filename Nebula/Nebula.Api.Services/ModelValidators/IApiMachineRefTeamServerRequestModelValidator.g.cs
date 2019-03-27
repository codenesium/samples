using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiMachineRefTeamServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineRefTeamServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRefTeamServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>409349d8227324dde5a8a732d870ad75</Hash>
</Codenesium>*/