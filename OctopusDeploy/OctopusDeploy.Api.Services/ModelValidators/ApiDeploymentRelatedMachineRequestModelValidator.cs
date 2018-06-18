using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiDeploymentRelatedMachineRequestModelValidator: AbstractApiDeploymentRelatedMachineRequestModelValidator, IApiDeploymentRelatedMachineRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>e1683c081a98d790b4fac6b98c29e849</Hash>
</Codenesium>*/