using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IMachineRefTeamModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(MachineRefTeamModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, MachineRefTeamModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0373d50a4ec8d2aca07776742463b789</Hash>
</Codenesium>*/