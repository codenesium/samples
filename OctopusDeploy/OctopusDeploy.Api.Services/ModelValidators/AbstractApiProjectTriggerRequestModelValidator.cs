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
        public abstract class AbstractApiProjectTriggerRequestModelValidator: AbstractValidator<ApiProjectTriggerRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiProjectTriggerRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProjectTriggerRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IProjectTriggerRepository ProjectTriggerRepository { get; set; }
                public virtual void IsDisabledRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetProjectIdName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProjectTriggerRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x.ProjectId).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetProjectIdName).When(x => x ?.ProjectId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProjectTriggerRequestModel.ProjectId));
                        this.RuleFor(x => x.ProjectId).Length(0, 50);
                }

                public virtual void TriggerTypeRules()
                {
                        this.RuleFor(x => x.TriggerType).Length(0, 50);
                }

                private async Task<bool> BeUniqueGetProjectIdName(ApiProjectTriggerRequestModel model,  CancellationToken cancellationToken)
                {
                        ProjectTrigger record = await this.ProjectTriggerRepository.GetProjectIdName(model.ProjectId, model.Name);

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
    <Hash>40990cdbe512a7b3f5ca573ec5c3506a</Hash>
</Codenesium>*/