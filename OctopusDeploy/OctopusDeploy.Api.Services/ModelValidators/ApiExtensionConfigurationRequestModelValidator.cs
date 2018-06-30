using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiExtensionConfigurationRequestModelValidator : AbstractApiExtensionConfigurationRequestModelValidator, IApiExtensionConfigurationRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>c9a183a827ff17772135a30a3f7f7134</Hash>
</Codenesium>*/