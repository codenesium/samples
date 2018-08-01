using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiUserRoleRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUserRoleRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRoleRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>8a178464e9fa7da3784978dc01a8e5d0</Hash>
</Codenesium>*/