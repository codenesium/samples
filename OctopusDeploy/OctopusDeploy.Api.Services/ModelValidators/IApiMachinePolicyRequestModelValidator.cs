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
    <Hash>3ac23fdb7f7b6d75620f61a714b9bbc5</Hash>
</Codenesium>*/