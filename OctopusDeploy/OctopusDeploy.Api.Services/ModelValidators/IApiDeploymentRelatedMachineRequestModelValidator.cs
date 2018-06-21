using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiDeploymentRelatedMachineRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDeploymentRelatedMachineRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeploymentRelatedMachineRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>d3097a386203f8da2472ab8d4fd776b1</Hash>
</Codenesium>*/