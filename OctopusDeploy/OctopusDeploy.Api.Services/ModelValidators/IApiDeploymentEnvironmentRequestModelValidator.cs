using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiDeploymentEnvironmentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentEnvironmentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentEnvironmentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>53f6aae6425e33f0de6590e7df77447d</Hash>
</Codenesium>*/