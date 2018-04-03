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

		public IFileTypeRepository FileTypeRepository {get; set;}
		public IBucketRepository BucketRepository {get; set;}
		public virtual void ExternalIdRules()
		{
			RuleFor(x => x.ExternalId).NotNull();
		}

		public virtual void PrivateKeyRules()
		{
			RuleFor(x => x.PrivateKey).NotNull();
			RuleFor(x => x.PrivateKey).Length(0,64);
		}

		public virtual void PublicKeyRules()
		{
			RuleFor(x => x.PublicKey).NotNull();
			RuleFor(x => x.PublicKey).Length(0,64);
		}

		public virtual void LocationRules()
		{
			RuleFor(x => x.Location).NotNull();
			RuleFor(x => x.Location).Length(0,255);
		}

		public virtual void ExpirationRules()
		{
			RuleFor(x => x.Expiration).NotNull();
		}

		public virtual void ExtensionRules()
		{
			RuleFor(x => x.Extension).NotNull();
			RuleFor(x => x.Extension).Length(0,32);
		}

		public virtual void DateCreatedRules()
		{
			RuleFor(x => x.DateCreated).NotNull();
		}

		public virtual void FileSizeInBytesRules()
		{
			RuleFor(x => x.FileSizeInBytes).NotNull();
		}

		public virtual void FileTypeIdRules()
		{
			RuleFor(x => x.FileTypeId).NotNull();
			RuleFor(x => x.FileTypeId).Must(BeValidFileType).When(x => x ?.FileTypeId != null).WithMessage("Invalid reference");
		}

		public virtual void BucketIdRules()
		{
			RuleFor(x => x.BucketId).Must(BeValidBucket).When(x => x ?.BucketId != null).WithMessage("Invalid reference");
		}

		public virtual void DescriptionRules()
		{
			RuleFor(x => x.Description).Length(0,255);
		}

		public bool BeValidFileType(int id)
		{
			Response response = new Response();

			this.FileTypeRepository.GetById(id,response);
			return response.FileTypes.Count > 0;
		}

		public bool BeValidBucket(Nullable<int> id)
		{
			Response response = new Response();

			this.BucketRepository.GetById(id.GetValueOrDefault(),response);
			return response.Buckets.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>cc77e5782f7615fbadefa7f46d78bfbb</Hash>
</Codenesium>*/