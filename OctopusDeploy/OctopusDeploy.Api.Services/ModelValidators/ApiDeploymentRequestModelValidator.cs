using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiDeploymentRequestModelValidator: AbstractApiDeploymentRequestModelValidator, IApiDeploymentRequestModelValidator
        {
                public ApiDeploymentRequestModelValidator(IDeploymentRepository deploymentRepository)
                        : base(deploymentRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiDeploymentRequestModel model)
                {
                        this.ChannelIdRules();
                        this.CreatedRules();
                        this.DeployedByRules();
                        this.DeployedToMachineIdsRules();
                        this.EnvironmentIdRules();
                        this.JSONRules();
                        this.NameRules();
                        this.ProjectGroupIdRules();
                        this.ProjectIdRules();
                        this.ReleaseIdRules();
                        this.TaskIdRules();
                        this.TenantIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentRequestModel model)
                {
                        this.ChannelIdRules();
                        this.CreatedRules();
                        this.DeployedByRules();
                        this.DeployedToMachineIdsRules();
                        this.EnvironmentIdRules();
                        this.JSONRules();
                        this.NameRules();
                        this.ProjectGroupIdRules();
                        this.ProjectIdRules();
                        this.ReleaseIdRules();
                        this.TaskIdRules();
                        this.TenantIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>63f702fb098e62ed681085e49f4de9e6</Hash>
</Codenesium>*/