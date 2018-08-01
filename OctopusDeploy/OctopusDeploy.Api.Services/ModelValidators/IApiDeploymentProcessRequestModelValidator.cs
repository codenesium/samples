using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiDeploymentProcessRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentProcessRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentProcessRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>82fe8b95025edcfc4fb296577ae84669</Hash>
</Codenesium>*/