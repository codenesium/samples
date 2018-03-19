using System.Threading.Tasks;
using FluentValidation.Results;

using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.Service
{
	public interface IMachineRefTeamModelValidator
	{
		ValidationResult Validate(MachineRefTeamModel entity);

		Task<ValidationResult> ValidateAsync(MachineRefTeamModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>39351277a23646e6bd9dc3616c573e71</Hash>
</Codenesium>*/