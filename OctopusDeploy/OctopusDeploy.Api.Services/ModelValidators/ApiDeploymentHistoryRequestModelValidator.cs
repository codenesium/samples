using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiDeploymentHistoryRequestModelValidator: AbstractApiDeploymentHistoryRequestModelValidator, IApiDeploymentHistoryRequestModelValidator
        {
                public ApiDeploymentHistoryRequestModelValidator(IDeploymentHistoryRepository deploymentHistoryRepository)
                        : base(deploymentHistoryRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiDeploymentHistoryRequestModel model)
                {
                        this.ChannelIdRules();
                        this.ChannelNameRules();
                        this.CompletedTimeRules();
                        this.CreatedRules();
                        this.DeployedByRules();
                        this.DeploymentNameRules();
                        this.DurationSecondsRules();
                        this.EnvironmentIdRules();
                        this.EnvironmentNameRules();
                        this.ProjectIdRules();
                        this.ProjectNameRules();
                        this.ProjectSlugRules();
                        this.QueueTimeRules();
                        this.ReleaseIdRules();
                        this.ReleaseVersionRules();
                        this.StartTimeRules();
                        this.TaskIdRules();
                        this.TaskStateRules();
                        this.TenantIdRules();
                        this.TenantNameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentHistoryRequestModel model)
                {
                        this.ChannelIdRules();
                        this.ChannelNameRules();
                        this.CompletedTimeRules();
                        this.CreatedRules();
                        this.DeployedByRules();
                        this.DeploymentNameRules();
                        this.DurationSecondsRules();
                        this.EnvironmentIdRules();
                        this.EnvironmentNameRules();
                        this.ProjectIdRules();
                        this.ProjectNameRules();
                        this.ProjectSlugRules();
                        this.QueueTimeRules();
                        this.ReleaseIdRules();
                        this.ReleaseVersionRules();
                        this.StartTimeRules();
                        this.TaskIdRules();
                        this.TaskStateRules();
                        this.TenantIdRules();
                        this.TenantNameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>87410ad32f3d7e44310c71ffb4d845f6</Hash>
</Codenesium>*/