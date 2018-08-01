using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiTenantRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTenantRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiTenantRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>992a6f41a587ce80f09b207c7a923517</Hash>
</Codenesium>*/