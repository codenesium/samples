using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>134fb9000cfdeb63390a8f956b770e26</Hash>
</Codenesium>*/