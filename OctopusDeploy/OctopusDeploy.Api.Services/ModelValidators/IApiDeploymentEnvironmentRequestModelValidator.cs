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
    <Hash>77996e1d04d03cbd30b99fd9a42d71a5</Hash>
</Codenesium>*/