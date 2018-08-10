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
    <Hash>82979a3fc2e697528d8b7f006082774c</Hash>
</Codenesium>*/