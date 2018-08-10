using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiKeyAllocationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiKeyAllocationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiKeyAllocationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>fa69b3bd2d85cb0df0fcce538e3e8645</Hash>
</Codenesium>*/