using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Service
{
	public interface IMachineModelValidator
	{
		ValidationResult Validate(MachineModel entity);

		Task<ValidationResult> ValidateAsync(MachineModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>72d8df9c7d7264074454f93c1d2c8503</Hash>
</Codenesium>*/