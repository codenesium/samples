using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
        public abstract class AbstractApiBucketRequestModelValidator : AbstractValidator<ApiBucketRequestModel>
        {
                private int existingRecordId;

                private IBucketRepository bucketRepository;

                public AbstractApiBucketRequestModelValidator(IBucketRepository bucketRepository)
                {
                        this.bucketRepository = bucketRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiBucketRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ExternalIdRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetExternalId).When(x => x?.ExternalId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketRequestModel.ExternalId));
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 255);
                }

                private async Task<bool> BeUniqueGetExternalId(ApiBucketRequestModel model,  CancellationToken cancellationToken)
                {
                        Bucket record = await this.bucketRepository.GetExternalId(model.ExternalId);

                        if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }

                private async Task<bool> BeUniqueGetName(ApiBucketRequestModel model,  CancellationToken cancellationToken)
                {
                        Bucket record = await this.bucketRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
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
    <Hash>2bd95ab9d63751a5a88f96f64e2239d5</Hash>
</Codenesium>*/