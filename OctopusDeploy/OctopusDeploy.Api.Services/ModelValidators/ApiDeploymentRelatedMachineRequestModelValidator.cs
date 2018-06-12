using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiDeploymentRelatedMachineRequestModelValidator: AbstractApiDeploymentRelatedMachineRequestModelValidator, IApiDeploymentRelatedMachineRequestModelValidator
        {
                public ApiDeploymentRelatedMachineRequestModelValidator()
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
    <Hash>c7e3b8b18c87da51910037f74f356a8b</Hash>
</Codenesium>*/