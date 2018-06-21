using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiLifecycleRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLifecycleRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiLifecycleRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>8d65db2ab3af7c2884c1ae6ce341b1e1</Hash>
</Codenesium>*/