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
    <Hash>e797afb35e6e52fec1f0f805293282ed</Hash>
</Codenesium>*/