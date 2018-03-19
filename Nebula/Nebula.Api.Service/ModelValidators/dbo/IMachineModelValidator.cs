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
    <Hash>a9962c979d361e7877bd7156e9b40a40</Hash>
</Codenesium>*/