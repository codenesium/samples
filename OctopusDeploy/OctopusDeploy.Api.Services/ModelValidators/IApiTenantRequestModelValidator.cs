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
    <Hash>feab6ffdd1f77eb2fd14ad8ffb5857ca</Hash>
</Codenesium>*/