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

                public ValidationResult Validate(ApiChannelRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiChannelRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IChannelRepository ChannelRepository { get; set; }
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
                        Channel record = await this.ChannelRepository.GetNameProjectId(model.Name, model.ProjectId);

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
    <Hash>667a66a4c3f1481af394fd14b83a33a2</Hash>
</Codenesium>*/