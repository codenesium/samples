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
    <Hash>228efa64eaf8d5f45b1c8e7232e1e0e4</Hash>
</Codenesium>*/