using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiTenantRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTenantRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiTenantRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>ab0e68ee5aa2de4bb9b97670afa3bd14</Hash>
</Codenesium>*/