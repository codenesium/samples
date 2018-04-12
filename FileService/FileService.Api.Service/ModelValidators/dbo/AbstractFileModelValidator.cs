using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service

{
	public abstract class AbstractFileModelValidator: AbstractValidator<FileModel>
	{
		public new ValidationResult Validate(FileModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(FileModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IFileTypeRepository FileTypeRepository { get; set; }
		public IBucketRepository BucketRepository { get; set; }
		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x.ExternalId).NotNull();
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

		public virtual void LocationRules()
		{
			this.RuleFor(x => x.Location).NotNull();
			this.RuleFor(x => x.Location).Length(0, 255);
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

		public virtual void DateCreatedRules()
		{
			this.RuleFor(x => x.DateCreated).NotNull();
		}

		public virtual void FileSizeInBytesRules()
		{
			this.RuleFor(x => x.FileSizeInBytes).NotNull();
		}

		public virtual void FileTypeIdRules()
		{
			this.RuleFor(x => x.FileTypeId).NotNull();
			this.RuleFor(x => x.FileTypeId).Must(this.BeValidFileType).When(x => x ?.FileTypeId != null).WithMessage("Invalid reference");
		}

		public virtual void BucketIdRules()
		{
			this.RuleFor(x => x.BucketId).Must(this.BeValidBucket).When(x => x ?.BucketId != null).WithMessage("Invalid reference");
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).Length(0, 255);
		}

		private bool BeValidFileType(int id)
		{
			return this.FileTypeRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidBucket(Nullable<int> id)
		{
			return this.BucketRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}
	}
}

/*<Codenesium>
    <Hash>cbdcae5e2c033d5127e2f98b07ad05c2</Hash>
</Codenesium>*/