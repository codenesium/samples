using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiMachinePolicyRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiMachinePolicyRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiMachinePolicyRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>319bbdc566e34a90238594c688cfe13d</Hash>
</Codenesium>*/