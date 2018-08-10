using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiConfigurationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiConfigurationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiConfigurationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>4a0abb0819b95e587d6e35ffc69d3ad1</Hash>
</Codenesium>*/