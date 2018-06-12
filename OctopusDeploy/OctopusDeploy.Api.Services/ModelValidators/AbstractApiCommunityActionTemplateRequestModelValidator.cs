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

                public ValidationResult Validate(ApiCommunityActionTemplateRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiCommunityActionTemplateRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ICommunityActionTemplateRepository CommunityActionTemplateRepository { get; set; }
                public virtual void ExternalIdRules()
                {
                        this.RuleFor(x => x.ExternalId).NotNull();
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
                        CommunityActionTemplate record = await this.CommunityActionTemplateRepository.GetExternalId(model.ExternalId);

                        if (record == null || record.Id == this.existingRecordId)
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
                        CommunityActionTemplate record = await this.CommunityActionTemplateRepository.GetName(model.Name);

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
    <Hash>b362c3e7922bc79927a1a2f14f9f4678</Hash>
</Codenesium>*/