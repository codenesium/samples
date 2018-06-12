using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiApiKeyRequestModelValidator: AbstractApiApiKeyRequestModelValidator, IApiApiKeyRequestModelValidator
        {
                public ApiApiKeyRequestModelValidator()
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
    <Hash>2e576e8c8d38b4e66ee72465d3c3716e</Hash>
</Codenesium>*/