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
        public abstract class AbstractApiActionTemplateRequestModelValidator : AbstractValidator<ApiActionTemplateRequestModel>
        {
                private string existingRecordId;

                private IActionTemplateRepository actionTemplateRepository;

                public AbstractApiActionTemplateRequestModelValidator(IActionTemplateRepository actionTemplateRepository)
                {
                        this.actionTemplateRepository = actionTemplateRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiActionTemplateRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ActionTypeRules()
                {
                        this.RuleFor(x => x.ActionType).NotNull();
                        this.RuleFor(x => x.ActionType).Length(0, 50);
                }

                public virtual void CommunityActionTemplateIdRules()
                {
                        this.RuleFor(x => x.CommunityActionTemplateId).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiActionTemplateRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void VersionRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiActionTemplateRequestModel model,  CancellationToken cancellationToken)
                {
                        ActionTemplate record = await this.actionTemplateRepository.GetName(model.Name);

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
    <Hash>03e35fbf750d5dd5e1aa7ad83d6c1a2a</Hash>
</Codenesium>*/