using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiConfigurationRequestModelValidator: AbstractApiConfigurationRequestModelValidator, IApiConfigurationRequestModelValidator
        {
                public ApiConfigurationRequestModelValidator()
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
    <Hash>8543ade6b286e7ede5f47b0b8953501c</Hash>
</Codenesium>*/