using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiDashboardConfigurationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDashboardConfigurationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDashboardConfigurationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>35840eddd6982ff8806fe53a798037ed</Hash>
</Codenesium>*/