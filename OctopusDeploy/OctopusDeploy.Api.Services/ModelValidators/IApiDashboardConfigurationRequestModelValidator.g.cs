using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiDashboardConfigurationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDashboardConfigurationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDashboardConfigurationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>dc6de542e9c236f9a5ad963a598f9c80</Hash>
</Codenesium>*/