using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiMutexRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiMutexRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiMutexRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>d063c37cb4ff573e19d548740c543809</Hash>
</Codenesium>*/