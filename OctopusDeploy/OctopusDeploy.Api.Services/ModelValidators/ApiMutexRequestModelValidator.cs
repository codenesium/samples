using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiMutexRequestModelValidator: AbstractApiMutexRequestModelValidator, IApiMutexRequestModelValidator
        {
                public ApiMutexRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiMutexRequestModel model)
                {
                        this.JSONRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiMutexRequestModel model)
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
    <Hash>b913e33640bdbbe2a9950bb95917fa29</Hash>
</Codenesium>*/