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
    <Hash>714b9933d0566b1cdffead25e5672885</Hash>
</Codenesium>*/