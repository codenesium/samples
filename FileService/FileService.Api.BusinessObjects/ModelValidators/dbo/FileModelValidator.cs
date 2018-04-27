using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public class FileModelValidator: AbstractFileModelValidator, IFileModelValidator
	{
		public FileModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(FileModel model)
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, FileModel model)
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>f397733d05de1256ad38ff51ec34e003</Hash>
</Codenesium>*/