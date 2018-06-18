using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiConfigurationRequestModelValidator: AbstractApiConfigurationRequestModelValidator, IApiConfigurationRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>d89c0d96fd57c4b7dee44d18db4421cd</Hash>
</Codenesium>*/