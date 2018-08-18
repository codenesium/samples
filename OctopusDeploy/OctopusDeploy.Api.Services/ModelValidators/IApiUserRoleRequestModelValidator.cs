using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiUserRoleRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUserRoleRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRoleRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>080b4312f251405fc8dddfe0d13ebffe</Hash>
</Codenesium>*/