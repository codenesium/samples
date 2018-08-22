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
    <Hash>5d3e17a2b6a40a4595969fbf07e411b4</Hash>
</Codenesium>*/