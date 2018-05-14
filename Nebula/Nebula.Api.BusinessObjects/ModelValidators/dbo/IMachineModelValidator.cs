using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiMachineModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e8a7452ac30ada7b673daace252c9807</Hash>
</Codenesium>*/