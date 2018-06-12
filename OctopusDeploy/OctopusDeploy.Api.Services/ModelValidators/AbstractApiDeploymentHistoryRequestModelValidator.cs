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
        public abstract class AbstractApiDeploymentHistoryRequestModelValidator: AbstractValidator<ApiDeploymentHistoryRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiDeploymentHistoryRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiDeploymentHistoryRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ChannelIdRules()
                {
                        this.RuleFor(x => x.ChannelId).Length(0, 50);
                }

                public virtual void ChannelNameRules()
                {
                        this.RuleFor(x => x.ChannelName).Length(0, 200);
                }

                public virtual void CompletedTimeRules()
                {
                }

                public virtual void CreatedRules()
                {
                        this.RuleFor(x => x.Created).NotNull();
                }

                public virtual void DeployedByRules()
                {
                        this.RuleFor(x => x.DeployedBy).Length(0, 200);
                }

                public virtual void DeploymentNameRules()
                {
                        this.RuleFor(x => x.DeploymentName).NotNull();
                        this.RuleFor(x => x.DeploymentName).Length(0, 200);
                }

                public virtual void DurationSecondsRules()
                {
                }

                public virtual void EnvironmentIdRules()
                {
                        this.RuleFor(x => x.EnvironmentId).NotNull();
                        this.RuleFor(x => x.EnvironmentId).Length(0, 50);
                }

                public virtual void EnvironmentNameRules()
                {
                        this.RuleFor(x => x.EnvironmentName).NotNull();
                        this.RuleFor(x => x.EnvironmentName).Length(0, 200);
                }

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x.ProjectId).NotNull();
                        this.RuleFor(x => x.ProjectId).Length(0, 50);
                }

                public virtual void ProjectNameRules()
                {
                        this.RuleFor(x => x.ProjectName).NotNull();
                        this.RuleFor(x => x.ProjectName).Length(0, 200);
                }

                public virtual void ProjectSlugRules()
                {
                        this.RuleFor(x => x.ProjectSlug).NotNull();
                        this.RuleFor(x => x.ProjectSlug).Length(0, 210);
                }

                public virtual void QueueTimeRules()
                {
                        this.RuleFor(x => x.QueueTime).NotNull();
                }

                public virtual void ReleaseIdRules()
                {
                        this.RuleFor(x => x.ReleaseId).NotNull();
                        this.RuleFor(x => x.ReleaseId).Length(0, 150);
                }

                public virtual void ReleaseVersionRules()
                {
                        this.RuleFor(x => x.ReleaseVersion).NotNull();
                        this.RuleFor(x => x.ReleaseVersion).Length(0, 100);
                }

                public virtual void StartTimeRules()
                {
                }

                public virtual void TaskIdRules()
                {
                        this.RuleFor(x => x.TaskId).NotNull();
                        this.RuleFor(x => x.TaskId).Length(0, 50);
                }

                public virtual void TaskStateRules()
                {
                        this.RuleFor(x => x.TaskState).NotNull();
                        this.RuleFor(x => x.TaskState).Length(0, 50);
                }

                public virtual void TenantIdRules()
                {
                        this.RuleFor(x => x.TenantId).Length(0, 50);
                }

                public virtual void TenantNameRules()
                {
                        this.RuleFor(x => x.TenantName).Length(0, 200);
                }
        }
}

/*<Codenesium>
    <Hash>60e3d9cb70ae9456a59e680430127454</Hash>
</Codenesium>*/