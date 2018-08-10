using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiDeploymentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>28343d901f029a4a8a8611311f7ad8a1</Hash>
</Codenesium>*/