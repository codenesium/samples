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
        public abstract class AbstractApiChannelRequestModelValidator : AbstractValidator<ApiChannelRequestModel>
        {
                private string existingRecordId;

                private IChannelRepository channelRepository;

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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByNameProjectId).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiChannelRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x.ProjectId).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByNameProjectId).When(x => x?.ProjectId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiChannelRequestModel.ProjectId));
                        this.RuleFor(x => x.ProjectId).Length(0, 50);
                }

                public virtual void TenantTagsRules()
                {
                }

                private async Task<bool> BeUniqueByNameProjectId(ApiChannelRequestModel model,  CancellationToken cancellationToken)
                {
                        Channel record = await this.channelRepository.ByNameProjectId(model.Name, model.ProjectId);

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
    <Hash>f8b5293aa8443224af55e1de678c6ae1</Hash>
</Codenesium>*/