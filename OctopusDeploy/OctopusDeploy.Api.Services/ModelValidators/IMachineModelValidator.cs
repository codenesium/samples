using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiMachineRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiMachineRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>2c9cbe4638046a0f91aa818f24337b98</Hash>
</Codenesium>*/