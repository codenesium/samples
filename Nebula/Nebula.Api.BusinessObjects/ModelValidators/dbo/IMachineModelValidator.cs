using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IMachineModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(MachineModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, MachineModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fb246e51a8aeaa4af3b0fc52d6c86b39</Hash>
</Codenesium>*/