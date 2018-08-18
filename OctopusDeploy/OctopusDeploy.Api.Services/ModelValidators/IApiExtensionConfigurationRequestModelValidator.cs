using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiExtensionConfigurationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiExtensionConfigurationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiExtensionConfigurationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>eef3b23dcc4077d32361b6d85f10e392</Hash>
</Codenesium>*/