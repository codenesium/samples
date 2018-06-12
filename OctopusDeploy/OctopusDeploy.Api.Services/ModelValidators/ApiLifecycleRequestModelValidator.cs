using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiLifecycleRequestModelValidator: AbstractApiLifecycleRequestModelValidator, IApiLifecycleRequestModelValidator
        {
                public ApiLifecycleRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLifecycleRequestModel model)
                {
                        this.DataVersionRules();
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiLifecycleRequestModel model)
                {
                        this.DataVersionRules();
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
    <Hash>bc65fad3c6aba729fc0450cddb14bd0d</Hash>
</Codenesium>*/