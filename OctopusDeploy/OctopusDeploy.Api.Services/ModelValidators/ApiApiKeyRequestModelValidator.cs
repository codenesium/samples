using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiApiKeyRequestModelValidator: AbstractApiApiKeyRequestModelValidator, IApiApiKeyRequestModelValidator
        {
                public ApiApiKeyRequestModelValidator(IApiKeyRepository apiKeyRepository)
                        : base(apiKeyRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiApiKeyRequestModel model)
                {
                        this.ApiKeyHashedRules();
                        this.CreatedRules();
                        this.JSONRules();
                        this.UserIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiApiKeyRequestModel model)
                {
                        this.ApiKeyHashedRules();
                        this.CreatedRules();
                        this.JSONRules();
                        this.UserIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>19249635a841eda77a7fc3f8c97c0f12</Hash>
</Codenesium>*/