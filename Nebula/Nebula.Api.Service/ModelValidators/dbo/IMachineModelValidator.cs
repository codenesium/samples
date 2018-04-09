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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>c2f70a52d50493562c7d6460df7b5ca4</Hash>
</Codenesium>*/