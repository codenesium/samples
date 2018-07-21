using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiReleaseRequestModelValidator : AbstractValidator<ApiReleaseRequestModel>
        {
                private string existingRecordId;

                private IReleaseRepository releaseRepository;

                public AbstractApiReleaseRequestModelValidator(IReleaseRepository releaseRepository)
                {
                        this.releaseRepository = releaseRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiReleaseRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AssembledRules()
                {
                }

                public virtual void ChannelIdRules()
                {
                        this.RuleFor(x => x.ChannelId).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                }

                public virtual void ProjectDeploymentProcessSnapshotIdRules()
                {
                        this.RuleFor(x => x.ProjectDeploymentProcessSnapshotId).Length(0, 150);
                }

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByVersionProjectId).When(x => x?.ProjectId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiReleaseRequestModel.ProjectId));
                        this.RuleFor(x => x.ProjectId).Length(0, 150);
                }

                public virtual void ProjectVariableSetSnapshotIdRules()
                {
                        this.RuleFor(x => x.ProjectVariableSetSnapshotId).Length(0, 150);
                }

                public virtual void VersionRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByVersionProjectId).When(x => x?.Version != null).WithMessage("Violates unique constraint").WithName(nameof(ApiReleaseRequestModel.Version));
                        this.RuleFor(x => x.Version).Length(0, 100);
                }

                private async Task<bool> BeUniqueByVersionProjectId(ApiReleaseRequestModel model,  CancellationToken cancellationToken)
                {
                        Release record = await this.releaseRepository.ByVersionProjectId(model.Version, model.ProjectId);

                        if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
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
    <Hash>50ee2bc513f5b99dd6b365037900912e</Hash>
</Codenesium>*/