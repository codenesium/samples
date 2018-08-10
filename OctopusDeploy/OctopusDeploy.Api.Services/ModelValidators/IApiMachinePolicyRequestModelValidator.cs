using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiMachinePolicyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachinePolicyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiMachinePolicyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>b7f8bee5abd2f7b3c84be55794fabac6</Hash>
</Codenesium>*/