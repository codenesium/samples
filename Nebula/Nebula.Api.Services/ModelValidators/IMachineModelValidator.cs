using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Services
{
	public interface IApiMachineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1ed650425b59ed1b3f0a1d31e0d00582</Hash>
</Codenesium>*/