using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiDeploymentProcessRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentProcessRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentProcessRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>2c9badf180006ee6e01d5a805907af35</Hash>
</Codenesium>*/