using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiMachineRefTeamRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineRefTeamRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRefTeamRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7a542683dba0902d66016c05170a5e06</Hash>
</Codenesium>*/