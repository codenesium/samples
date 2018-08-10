using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiMachineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>88b2b5ae882537e66571ba08d1d2bc35</Hash>
</Codenesium>*/