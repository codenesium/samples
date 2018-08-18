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
    <Hash>2a118813bf3d056f21d7eb4adca1412b</Hash>
</Codenesium>*/