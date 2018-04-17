using System;
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
    <Hash>6bee7c04d9561bc80c32c304c6c16a38</Hash>
</Codenesium>*/