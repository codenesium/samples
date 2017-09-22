using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;

using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service

{
	public class FileModelValidatorAbstract: AbstractValidator<FileModel>
	{
		public BucketRepository BucketRepository {get; set;}

		public FileTypeRepository FileTypeRepository {get; set;}

		public virtual void BucketIdRules()
		{
			RuleFor(x => x.BucketId).Must(BeValidBucket).When(x => x != null && x.BucketId != null).WithMessage("Invalid reference");
		}

		public virtual void DateCreatedRules()
		{
			RuleFor(x => x.DateCreated).NotNull();
		}

		public virtual void DescriptionRules()
		{
			RuleFor(x => x.Description).Length(0,255);
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

		public virtual void ExternalIdRules()
		{
			RuleFor(x => x.ExternalId).NotNull();
		}

		public virtual void FileSizeInBytesRules()
		{
			RuleFor(x => x.FileSizeInBytes).NotNull();
		}

		public virtual void FileTypeIdRules()
		{
			RuleFor(x => x.FileTypeId).NotNull();
			RuleFor(x => x.FileTypeId).Must(BeValidFileType).When(x => x != null && x.FileTypeId != null).WithMessage("Invalid reference");
		}

		public virtual void IdRules()
		{
			RuleFor(x => x.Id).NotNull();
		}

		public virtual void LocationRules()
		{
			RuleFor(x => x.Location).NotNull();
			RuleFor(x => x.Location).Length(0,255);
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

		public bool BeValidBucket(Nullable<int> id)
		{
			Response response = new Response();

			this.BucketRepository.GetById(id.GetValueOrDefault(),response);
			return response.Buckets.Count > 0;
		}

		public bool BeValidFileType(int id)
		{
			Response response = new Response();

			this.FileTypeRepository.GetById(id,response);
			return response.FileTypes.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>c20c63a2afd7e09b9c43f9296778dde7</Hash>
</Codenesium>*/