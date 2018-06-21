using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiMutexRequestModelValidator : AbstractApiMutexRequestModelValidator, IApiMutexRequestModelValidator
        {
                public ApiMutexRequestModelValidator(IMutexRepository mutexRepository)
                        : base(mutexRepository)
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>b419ece71b15f3e1623137880cb0d2c7</Hash>
</Codenesium>*/