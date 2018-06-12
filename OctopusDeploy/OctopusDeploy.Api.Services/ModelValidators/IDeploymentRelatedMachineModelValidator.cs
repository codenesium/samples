using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>ecee702646bedf2ae17a7f29fb7f86d2</Hash>
</Codenesium>*/