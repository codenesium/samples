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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>323fddb1a85113ba32fc3c03aff2a356</Hash>
</Codenesium>*/