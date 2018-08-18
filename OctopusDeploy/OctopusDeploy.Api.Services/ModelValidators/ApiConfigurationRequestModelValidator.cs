using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiConfigurationRequestModelValidator : AbstractApiConfigurationRequestModelValidator, IApiConfigurationRequestModelValidator
	{
		public ApiConfigurationRequestModelValidator(IConfigurationRepository configurationRepository)
			: base(configurationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiConfigurationRequestModel model)
		{
			this.JSONRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiConfigurationRequestModel model)
		{
			this.JSONRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>2f95082cd7d31fa8fc0e0d20e55bf75b</Hash>
</Codenesium>*/