using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractApiFileServerRequestModelValidator : AbstractValidator<ApiFileServerRequestModel>
	{
		private int existingRecordId;

		private IFileRepository fileRepository;

		public AbstractApiFileServerRequestModelValidator(IFileRepository fileRepository)
		{
			this.fileRepository = fileRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFileServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BucketIdRules()
		{
			this.RuleFor(x => x.BucketId).MustAsync(this.BeValidBucketByBucketId).When(x => !x?.BucketId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void DateCreatedRules()
		{
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).Length(0, 255);
		}

		public virtual void ExpirationRules()
		{
		}

		public virtual void ExtensionRules()
		{
			this.RuleFor(x => x.Extension).NotNull();
			this.RuleFor(x => x.Extension).Length(0, 32);
		}

		public virtual void ExternalIdRules()
		{
		}

		public virtual void FileSizeInByteRules()
		{
		}

		public virtual void FileTypeIdRules()
		{
			this.RuleFor(x => x.FileTypeId).MustAsync(this.BeValidFileTypeByFileTypeId).When(x => !x?.FileTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
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

		private async Task<bool> BeValidBucketByBucketId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.fileRepository.BucketByBucketId(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeValidFileTypeByFileTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.fileRepository.FileTypeByFileTypeId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>bf6d61ae4b02991420054cba26f59c63</Hash>
</Codenesium>*/