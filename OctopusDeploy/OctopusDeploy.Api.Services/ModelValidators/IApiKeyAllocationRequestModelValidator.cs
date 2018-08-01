using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiKeyAllocationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiKeyAllocationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiKeyAllocationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>f9485f738bc22c6473e6c65399e48d56</Hash>
</Codenesium>*/