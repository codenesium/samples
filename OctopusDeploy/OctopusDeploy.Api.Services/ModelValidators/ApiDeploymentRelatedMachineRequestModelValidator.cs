using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiDeploymentRelatedMachineRequestModelValidator : AbstractApiDeploymentRelatedMachineRequestModelValidator, IApiDeploymentRelatedMachineRequestModelValidator
        {
                public ApiDeploymentRelatedMachineRequestModelValidator(IDeploymentRelatedMachineRepository deploymentRelatedMachineRepository)
                        : base(deploymentRelatedMachineRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiDeploymentRelatedMachineRequestModel model)
                {
                        this.DeploymentIdRules();
                        this.MachineIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeploymentRelatedMachineRequestModel model)
                {
                        this.DeploymentIdRules();
                        this.MachineIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>d3d698835b8fe03d6cb4e985ee799ca2</Hash>
</Codenesium>*/