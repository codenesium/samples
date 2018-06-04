using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
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
    <Hash>0ea8e129362b71f28b8d663ffeb02894</Hash>
</Codenesium>*/