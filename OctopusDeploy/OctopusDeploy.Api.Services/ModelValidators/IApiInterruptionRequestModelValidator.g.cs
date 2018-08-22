using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiInterruptionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiInterruptionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiInterruptionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>45d637260c752d4e07431f28e058587b</Hash>
</Codenesium>*/