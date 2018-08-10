using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiTenantVariableRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTenantVariableRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiTenantVariableRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>632804db48edc5dcb9dcfd35cf1d48b4</Hash>
</Codenesium>*/