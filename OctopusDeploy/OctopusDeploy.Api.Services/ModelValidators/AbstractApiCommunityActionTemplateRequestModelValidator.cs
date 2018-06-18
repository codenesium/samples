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
        public abstract class AbstractApiCommunityActionTemplateRequestModelValidator: AbstractValidator<ApiCommunityActionTemplateRequestModel>
        {
                private string existingRecordId;

                ICommunityActionTemplateRepository communityActionTemplateRepository;

                public AbstractApiCommunityActionTemplateRequestModelValidator(ICommunityActionTemplateRepository communityActionTemplateRepository)
                {
                        this.communityActionTemplateRepository = communityActionTemplateRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiCommunityActionTemplateRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ExternalIdRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetExternalId).When(x => x ?.ExternalId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCommunityActionTemplateRequestModel.ExternalId));
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCommunityActionTemplateRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                private async Task<bool> BeUniqueGetExternalId(ApiCommunityActionTemplateRequestModel model,  CancellationToken cancellationToken)
                {
                        CommunityActionTemplate record = await this.communityActionTemplateRepository.GetExternalId(model.ExternalId);

                        if (record == null || (this.existingRecordId != default (string) && record.Id == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
                private async Task<bool> BeUniqueGetName(ApiCommunityActionTemplateRequestModel model,  CancellationToken cancellationToken)
                {
                        CommunityActionTemplate record = await this.communityActionTemplateRepository.GetName(model.Name);

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
    <Hash>1d00c9a5941571db5e096fb66196c834</Hash>
</Codenesium>*/