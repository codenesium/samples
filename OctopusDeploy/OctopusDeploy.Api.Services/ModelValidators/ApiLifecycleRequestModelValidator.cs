using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiLifecycleRequestModelValidator: AbstractApiLifecycleRequestModelValidator, IApiLifecycleRequestModelValidator
        {
                public ApiLifecycleRequestModelValidator(ILifecycleRepository lifecycleRepository)
                        : base(lifecycleRepository)
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
    <Hash>4d5470d9f7cfad40ed998c54132260a5</Hash>
</Codenesium>*/