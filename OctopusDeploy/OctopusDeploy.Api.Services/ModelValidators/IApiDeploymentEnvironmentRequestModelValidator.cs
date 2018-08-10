using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiDeploymentEnvironmentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentEnvironmentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentEnvironmentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>d149e6d93af1c435c67e7842e31b8a1c</Hash>
</Codenesium>*/