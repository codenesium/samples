using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiMachineRefTeamModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineRefTeamModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRefTeamModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2afbec5a85eed8619052c37db727a1fa</Hash>
</Codenesium>*/