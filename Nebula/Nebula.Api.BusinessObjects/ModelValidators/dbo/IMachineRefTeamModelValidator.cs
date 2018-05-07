using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IMachineRefTeamModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(MachineRefTeamModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, MachineRefTeamModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1b7e4a2013badf35daacccad9511477c</Hash>
</Codenesium>*/