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
    <Hash>9c60cec0313702cdac203b9104736020</Hash>
</Codenesium>*/