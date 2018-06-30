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
        public abstract class AbstractApiProjectRequestModelValidator : AbstractValidator<ApiProjectRequestModel>
        {
                private string existingRecordId;

                private IProjectRepository projectRepository;

                public AbstractApiProjectRequestModelValidator(IProjectRepository projectRepository)
                {
                        this.projectRepository = projectRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProjectRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AutoCreateReleaseRules()
                {
                }

                public virtual void DataVersionRules()
                {
                }

                public virtual void DeploymentProcessIdRules()
                {
                        this.RuleFor(x => x.DeploymentProcessId).Length(0, 50);
                }

                public virtual void DiscreteChannelReleaseRules()
                {
                }

                public virtual void IncludedLibraryVariableSetIdsRules()
                {
                }

                public virtual void IsDisabledRules()
                {
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProjectRequestModel.Name));
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueBySlug).When(x => x?.Slug != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProjectRequestModel.Slug));
                        this.RuleFor(x => x.Slug).Length(0, 210);
                }

                public virtual void VariableSetIdRules()
                {
                        this.RuleFor(x => x.VariableSetId).Length(0, 150);
                }

                private async Task<bool> BeUniqueByName(ApiProjectRequestModel model,  CancellationToken cancellationToken)
                {
                        Project record = await this.projectRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }

                private async Task<bool> BeUniqueBySlug(ApiProjectRequestModel model,  CancellationToken cancellationToken)
                {
                        Project record = await this.projectRepository.BySlug(model.Slug);

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
    <Hash>bcecbc7a64825e6d0a38b6d5186d50ff</Hash>
</Codenesium>*/