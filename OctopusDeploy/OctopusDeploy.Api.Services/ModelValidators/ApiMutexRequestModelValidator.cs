using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiMutexRequestModelValidator: AbstractApiMutexRequestModelValidator, IApiMutexRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>7ce9bd53c8eb79e0ec125992708db821</Hash>
</Codenesium>*/