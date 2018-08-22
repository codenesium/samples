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
    <Hash>adeed8830bb31e3711501e25a208b101</Hash>
</Codenesium>*/