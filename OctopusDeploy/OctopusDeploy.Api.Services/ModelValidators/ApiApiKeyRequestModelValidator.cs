using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiApiKeyRequestModelValidator : AbstractApiApiKeyRequestModelValidator, IApiApiKeyRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>1329d1670d9abf5adeb7d8150a3f115f</Hash>
</Codenesium>*/