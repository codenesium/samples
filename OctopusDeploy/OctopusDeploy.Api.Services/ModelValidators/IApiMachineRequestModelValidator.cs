using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiMachineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiMachineRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>1773817351f1939085fd4be29b5336f5</Hash>
</Codenesium>*/