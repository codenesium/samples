using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiConfigurationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiConfigurationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiConfigurationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>377bf86755602dfcae70cd997b8afd29</Hash>
</Codenesium>*/