using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services

{
        public abstract class AbstractApiFileRequestModelValidator: AbstractValidator<ApiFileRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiFileRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiFileRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IBucketRepository BucketRepository { get; set; }

                public IFileTypeRepository FileTypeRepository { get; set; }

                public virtual void BucketIdRules()
                {
                        this.RuleFor(x => x.BucketId).MustAsync(this.BeValidBucket).When(x => x ?.BucketId != null).WithMessage("Invalid reference");
                }

                public virtual void DateCreatedRules()
                {
                        this.RuleFor(x => x.DateCreated).NotNull();
                }

                public virtual void DescriptionRules()
                {
                        this.RuleFor(x => x.Description).Length(0, 255);
                }

                public virtual void ExpirationRules()
                {
                        this.RuleFor(x => x.Expiration).NotNull();
                }

                public virtual void ExtensionRules()
                {
                        this.RuleFor(x => x.Extension).NotNull();
                        this.RuleFor(x => x.Extension).Length(0, 32);
                }

                public virtual void ExternalIdRules()
                {
                        this.RuleFor(x => x.ExternalId).NotNull();
                }

                public virtual void FileSizeInBytesRules()
                {
                        this.RuleFor(x => x.FileSizeInBytes).NotNull();
                }

                public virtual void FileTypeIdRules()
                {
                        this.RuleFor(x => x.FileTypeId).NotNull();
                        this.RuleFor(x => x.FileTypeId).MustAsync(this.BeValidFileType).When(x => x ?.FileTypeId != null).WithMessage("Invalid reference");
                }

                public virtual void LocationRules()
                {
                        this.RuleFor(x => x.Location).NotNull();
                        this.RuleFor(x => x.Location).Length(0, 255);
                }

                public virtual void PrivateKeyRules()
                {
                        this.RuleFor(x => x.PrivateKey).NotNull();
                        this.RuleFor(x => x.PrivateKey).Length(0, 64);
                }

                public virtual void PublicKeyRules()
                {
                        this.RuleFor(x => x.PublicKey).NotNull();
                        this.RuleFor(x => x.PublicKey).Length(0, 64);
                }

                private async Task<bool> BeValidBucket(Nullable<int> id,  CancellationToken cancellationToken)
                {
                        var record = await this.BucketRepository.Get(id.GetValueOrDefault());

                        return record != null;
                }

                private async Task<bool> BeValidFileType(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.FileTypeRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>146012264e1b6d20317057ca42a58ee5</Hash>
</Codenesium>*/