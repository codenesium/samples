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
	public abstract class AbstractApiFileServerRequestModelValidator : AbstractValidator<ApiFileServerRequestModel>
	{
		private int existingRecordId;

		protected IFileRepository FileRepository { get; private set; }

		public AbstractApiFileServerRequestModelValidator(IFileRepository fileRepository)
		{
			this.FileRepository = fileRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFileServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BucketIdRules()
		{
			this.RuleFor(x => x.BucketId).MustAsync(this.BeValidBucketByBucketId).When(x => !x?.BucketId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void DateCreatedRules()
		{
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).Length(0, 255).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ExpirationRules()
		{
		}

		public virtual void ExtensionRules()
		{
			this.RuleFor(x => x.Extension).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Extension).Length(0, 32).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ExternalIdRules()
		{
		}

		public virtual void FileSizeInByteRules()
		{
		}

		public virtual void FileTypeIdRules()
		{
			this.RuleFor(x => x.FileTypeId).MustAsync(this.BeValidFileTypeByFileTypeId).When(x => !x?.FileTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void LocationRules()
		{
			this.RuleFor(x => x.Location).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Location).Length(0, 255).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PrivateKeyRules()
		{
			this.RuleFor(x => x.PrivateKey).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PrivateKey).Length(0, 64).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PublicKeyRules()
		{
			this.RuleFor(x => x.PublicKey).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PublicKey).Length(0, 64).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidBucketByBucketId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.FileRepository.BucketByBucketId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidFileTypeByFileTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.FileRepository.FileTypeByFileTypeId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>20fe309bcfda137af1e28229bac1e5ee</Hash>
</Codenesium>*/