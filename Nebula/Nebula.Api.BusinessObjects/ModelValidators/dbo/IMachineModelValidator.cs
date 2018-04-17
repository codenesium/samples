using System;
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
    <Hash>3737ee0c2bf7bfd565f1677ca43a854c</Hash>
</Codenesium>*/