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
                        this.RuleFor(x => x.ActionType).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                }

                public virtual void LatestActionTemplateIdRules()
                {
                        this.RuleFor(x => x.LatestActionTemplateId).Length(0, 50);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByNameVersion).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiActionTemplateVersionRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void VersionRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByNameVersion).When(x => x?.Version != null).WithMessage("Violates unique constraint").WithName(nameof(ApiActionTemplateVersionRequestModel.Version));
                }

                private async Task<bool> BeUniqueByNameVersion(ApiActionTemplateVersionRequestModel model,  CancellationToken cancellationToken)
                {
                        ActionTemplateVersion record = await this.actionTemplateVersionRepository.ByNameVersion(model.Name, model.Version);

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
    <Hash>819fa0b54f5712eb78e7d7965016c0aa</Hash>
</Codenesium>*/