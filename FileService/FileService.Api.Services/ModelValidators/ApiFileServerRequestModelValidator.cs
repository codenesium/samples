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
	public class ApiFileServerRequestModelValidator : AbstractValidator<ApiFileServerRequestModel>, IApiFileServerRequestModelValidator
	{
		private int existingRecordId;

		protected IFileRepository FileRepository { get; private set; }

		public ApiFileServerRequestModelValidator(IFileRepository fileRepository)
		{
			this.FileRepository = fileRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFileServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFileServerRequestModel model)
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInByteRules();
			this.FileTypeIdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileServerRequestModel model)
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInByteRules();
			this.FileTypeIdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>7c10ed7c5c2691499f6263a9dd28819b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/