using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiExtensionConfigurationRequestModelValidator: AbstractApiExtensionConfigurationRequestModelValidator, IApiExtensionConfigurationRequestModelValidator
        {
                public ApiExtensionConfigurationRequestModelValidator(IExtensionConfigurationRepository extensionConfigurationRepository)
                        : base(extensionConfigurationRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiExtensionConfigurationRequestModel model)
                {
                        this.ExtensionAuthorRules();
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiExtensionConfigurationRequestModel model)
                {
                        this.ExtensionAuthorRules();
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>d77c9aa74bbe2acce61048531993f4e6</Hash>
</Codenesium>*/