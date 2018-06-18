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
        public abstract class AbstractApiChannelRequestModelValidator: AbstractValidator<ApiChannelRequestModel>
        {
                private string existingRecordId;

                IChannelRepository channelRepository;

                public AbstractApiChannelRequestModelValidator(IChannelRepository channelRepository)
                {
                        this.channelRepository = channelRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiChannelRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DataVersionRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void LifecycleIdRules()
                {
                        this.RuleFor(x => x.LifecycleId).Length(0, 50);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetNameProjectId).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiChannelRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x.ProjectId).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetNameProjectId).When(x => x ?.ProjectId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiChannelRequestModel.ProjectId));
                        this.RuleFor(x => x.ProjectId).Length(0, 50);
                }

                public virtual void TenantTagsRules()
                {
                }

                private async Task<bool> BeUniqueGetNameProjectId(ApiChannelRequestModel model,  CancellationToken cancellationToken)
                {
                        Channel record = await this.channelRepository.GetNameProjectId(model.Name, model.ProjectId);

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
    <Hash>d9613ba62ff1949e9392ab16ed8b5dd4</Hash>
</Codenesium>*/