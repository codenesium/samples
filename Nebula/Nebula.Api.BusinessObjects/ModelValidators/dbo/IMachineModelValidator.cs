using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiMachineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5368b0dee428fd0a1a4746293496b99f</Hash>
</Codenesium>*/