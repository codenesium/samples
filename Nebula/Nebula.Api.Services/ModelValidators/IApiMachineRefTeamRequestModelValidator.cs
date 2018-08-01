using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IApiMachineRefTeamRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineRefTeamRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRefTeamRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a094756b989d26b6ab57922e3ef992c4</Hash>
</Codenesium>*/