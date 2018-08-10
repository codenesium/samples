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
    <Hash>6f93e82799a3fe5ff200c073810e16fa</Hash>
</Codenesium>*/