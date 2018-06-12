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
        public abstract class AbstractApiProjectRequestModelValidator: AbstractValidator<ApiProjectRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiProjectRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProjectRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IProjectRepository ProjectRepository { get; set; }
                public virtual void AutoCreateReleaseRules()
                {
                        this.RuleFor(x => x.AutoCreateRelease).NotNull();
                }

                public virtual void DataVersionRules()
                {
                        this.RuleFor(x => x.DataVersion).NotNull();
                }

                public virtual void DeploymentProcessIdRules()
                {
                        this.RuleFor(x => x.DeploymentProcessId).Length(0, 50);
                }

                public virtual void DiscreteChannelReleaseRules()
                {
                        this.RuleFor(x => x.DiscreteChannelRelease).NotNull();
                }

                public virtual void IncludedLibraryVariableSetIdsRules()
                {
                }

                public virtual void IsDisabledRules()
                {
                        this.RuleFor(x => x.IsDisabled).NotNull();
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void LifecycleIdRules()
                {
                        this.RuleFor(x => x.LifecycleId).NotNull();
                        this.RuleFor(x => x.LifecycleId).Length(0, 50);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProjectRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void ProjectGroupIdRules()
                {
                        this.RuleFor(x => x.ProjectGroupId).NotNull();
                        this.RuleFor(x => x.ProjectGroupId).Length(0, 50);
                }

                public virtual void SlugRules()
                {
                        this.RuleFor(x => x.Slug).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetSlug).When(x => x ?.Slug != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProjectRequestModel.Slug));
                        this.RuleFor(x => x.Slug).Length(0, 210);
                }

                public virtual void VariableSetIdRules()
                {
                        this.RuleFor(x => x.VariableSetId).Length(0, 150);
                }

                private async Task<bool> BeUniqueGetName(ApiProjectRequestModel model,  CancellationToken cancellationToken)
                {
                        Project record = await this.ProjectRepository.GetName(model.Name);

                        if (record == null || record.Id == this.existingRecordId)
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
                private async Task<bool> BeUniqueGetSlug(ApiProjectRequestModel model,  CancellationToken cancellationToken)
                {
                        Project record = await this.ProjectRepository.GetSlug(model.Slug);

                        if (record == null || record.Id == this.existingRecordId)
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
    <Hash>6af9216d73bc3056c8b88e4f4cbdd1ec</Hash>
</Codenesium>*/