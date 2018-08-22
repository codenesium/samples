using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiMachineRefTeamRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineRefTeamRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRefTeamRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1de34842378ecbeb1ef16a62f4ecf6d5</Hash>
</Codenesium>*/