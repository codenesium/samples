using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiMachinePolicyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachinePolicyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiMachinePolicyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>af1d2be99c4f537dc2deddd083ae042d</Hash>
</Codenesium>*/