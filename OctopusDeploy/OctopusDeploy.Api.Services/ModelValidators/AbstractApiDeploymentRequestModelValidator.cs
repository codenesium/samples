using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiDeploymentRequestModelValidator: AbstractValidator<ApiDeploymentRequestModel>
        {
                private string existingRecordId;

                IDeploymentRepository deploymentRepository;

                public AbstractApiDeploymentRequestModelValidator(IDeploymentRepository deploymentRepository)
                {
                        this.deploymentRepository = deploymentRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiDeploymentRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ChannelIdRules()
                {
                        this.RuleFor(x => x.ChannelId).NotNull();
                        this.RuleFor(x => x.ChannelId).Length(0, 50);
                }

                public virtual void CreatedRules()
                {
                }

                public virtual void DeployedByRules()
                {
                        this.RuleFor(x => x.DeployedBy).NotNull();
                        this.RuleFor(x => x.DeployedBy).Length(0, 200);
                }

                public virtual void DeployedToMachineIdsRules()
                {
                }

                public virtual void EnvironmentIdRules()
                {
                        this.RuleFor(x => x.EnvironmentId).NotNull();
                        this.RuleFor(x => x.EnvironmentId).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void ProjectGroupIdRules()
                {
                        this.RuleFor(x => x.ProjectGroupId).NotNull();
                        this.RuleFor(x => x.ProjectGroupId).Length(0, 50);
                }

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x.ProjectId).NotNull();
                        this.RuleFor(x => x.ProjectId).Length(0, 50);
                }

                public virtual void ReleaseIdRules()
                {
                        this.RuleFor(x => x.ReleaseId).NotNull();
                        this.RuleFor(x => x.ReleaseId).Length(0, 50);
                }

                public virtual void TaskIdRules()
                {
                        this.RuleFor(x => x.TaskId).Length(0, 50);
                }

                public virtual void TenantIdRules()
                {
                        this.RuleFor(x => x.TenantId).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>1196b6de878a21aec92030ff800a538e</Hash>
</Codenesium>*/