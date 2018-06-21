using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>a646c270f622e35517db5c64c5408315</Hash>
</Codenesium>*/