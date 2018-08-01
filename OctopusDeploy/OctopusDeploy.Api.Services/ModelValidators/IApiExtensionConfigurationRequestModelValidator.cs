using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiExtensionConfigurationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiExtensionConfigurationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiExtensionConfigurationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>d0595053aff1f66ff6ffbf0fff215244</Hash>
</Codenesium>*/