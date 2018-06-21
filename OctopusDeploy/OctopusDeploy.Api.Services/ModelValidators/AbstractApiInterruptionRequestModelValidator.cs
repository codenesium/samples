using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiInterruptionRequestModelValidator : AbstractValidator<ApiInterruptionRequestModel>
        {
                private string existingRecordId;

                private IInterruptionRepository interruptionRepository;

                public AbstractApiInterruptionRequestModelValidator(IInterruptionRepository interruptionRepository)
                {
                        this.interruptionRepository = interruptionRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiInterruptionRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CreatedRules()
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

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x.ProjectId).NotNull();
                        this.RuleFor(x => x.ProjectId).Length(0, 50);
                }

                public virtual void RelatedDocumentIdsRules()
                {
                        this.RuleFor(x => x.RelatedDocumentIds).NotNull();
                }

                public virtual void ResponsibleTeamIdsRules()
                {
                        this.RuleFor(x => x.ResponsibleTeamIds).NotNull();
                }

                public virtual void StatusRules()
                {
                        this.RuleFor(x => x.Status).NotNull();
                        this.RuleFor(x => x.Status).Length(0, 50);
                }

                public virtual void TaskIdRules()
                {
                        this.RuleFor(x => x.TaskId).NotNull();
                        this.RuleFor(x => x.TaskId).Length(0, 50);
                }

                public virtual void TenantIdRules()
                {
                        this.RuleFor(x => x.TenantId).Length(0, 50);
                }

                public virtual void TitleRules()
                {
                        this.RuleFor(x => x.Title).NotNull();
                        this.RuleFor(x => x.Title).Length(0, 200);
                }
        }
}

/*<Codenesium>
    <Hash>699960c6940c2f8b34fb6b7019bfb792</Hash>
</Codenesium>*/