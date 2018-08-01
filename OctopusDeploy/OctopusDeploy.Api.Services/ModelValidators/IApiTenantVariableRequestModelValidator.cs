using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiTenantVariableRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTenantVariableRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiTenantVariableRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>835b1094dc6e3c4555cbf97f98f44a13</Hash>
</Codenesium>*/