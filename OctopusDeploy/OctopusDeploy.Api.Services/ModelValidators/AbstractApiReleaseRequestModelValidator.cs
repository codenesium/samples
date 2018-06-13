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
        public abstract class AbstractApiReleaseRequestModelValidator: AbstractValidator<ApiReleaseRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiReleaseRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiReleaseRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IReleaseRepository ReleaseRepository { get; set; }
                public virtual void AssembledRules()
                {
                }

                public virtual void ChannelIdRules()
                {
                        this.RuleFor(x => x.ChannelId).NotNull();
                        this.RuleFor(x => x.ChannelId).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void ProjectDeploymentProcessSnapshotIdRules()
                {
                        this.RuleFor(x => x.ProjectDeploymentProcessSnapshotId).NotNull();
                        this.RuleFor(x => x.ProjectDeploymentProcessSnapshotId).Length(0, 150);
                }

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x.ProjectId).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetVersionProjectId).When(x => x ?.ProjectId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiReleaseRequestModel.ProjectId));
                        this.RuleFor(x => x.ProjectId).Length(0, 150);
                }

                public virtual void ProjectVariableSetSnapshotIdRules()
                {
                        this.RuleFor(x => x.ProjectVariableSetSnapshotId).NotNull();
                        this.RuleFor(x => x.ProjectVariableSetSnapshotId).Length(0, 150);
                }

                public virtual void VersionRules()
                {
                        this.RuleFor(x => x.Version).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetVersionProjectId).When(x => x ?.Version != null).WithMessage("Violates unique constraint").WithName(nameof(ApiReleaseRequestModel.Version));
                        this.RuleFor(x => x.Version).Length(0, 100);
                }

                private async Task<bool> BeUniqueGetVersionProjectId(ApiReleaseRequestModel model,  CancellationToken cancellationToken)
                {
                        Release record = await this.ReleaseRepository.GetVersionProjectId(model.Version, model.ProjectId);

                        if (record == null || (this.existingRecordId != default (string) && record.Id == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>c7f19ed6a67711e898a499a02176ca30</Hash>
</Codenesium>*/