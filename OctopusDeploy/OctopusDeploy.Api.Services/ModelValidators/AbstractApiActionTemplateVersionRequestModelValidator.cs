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
        public abstract class AbstractApiActionTemplateVersionRequestModelValidator : AbstractValidator<ApiActionTemplateVersionRequestModel>
        {
                private string existingRecordId;

                private IActionTemplateVersionRepository actionTemplateVersionRepository;

                public AbstractApiActionTemplateVersionRequestModelValidator(IActionTemplateVersionRepository actionTemplateVersionRepository)
                {
                        this.actionTemplateVersionRepository = actionTemplateVersionRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiActionTemplateVersionRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ActionTypeRules()
                {
                        this.RuleFor(x => x.ActionType).NotNull();
                        this.RuleFor(x => x.ActionType).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void LatestActionTemplateIdRules()
                {
                        this.RuleFor(x => x.LatestActionTemplateId).NotNull();
                        this.RuleFor(x => x.LatestActionTemplateId).Length(0, 50);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetNameVersion).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiActionTemplateVersionRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void VersionRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetNameVersion).When(x => x?.Version != null).WithMessage("Violates unique constraint").WithName(nameof(ApiActionTemplateVersionRequestModel.Version));
                }

                private async Task<bool> BeUniqueGetNameVersion(ApiActionTemplateVersionRequestModel model,  CancellationToken cancellationToken)
                {
                        ActionTemplateVersion record = await this.actionTemplateVersionRepository.GetNameVersion(model.Name, model.Version);

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
    <Hash>6a2951d92437401bd0cad44a47029139</Hash>
</Codenesium>*/