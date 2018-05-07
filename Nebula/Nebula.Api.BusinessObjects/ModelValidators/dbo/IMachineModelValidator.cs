using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IMachineModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(MachineModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, MachineModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f0628ad7d64d62f1c79958087fe98aa0</Hash>
</Codenesium>*/