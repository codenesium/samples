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
			this.ExternalIdRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
			this.LocationRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.DateCreatedRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.BucketIdRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, FileModel model)
		{
			this.ExternalIdRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
			this.LocationRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.DateCreatedRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.BucketIdRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>9042dc1a407c9c7032d4b388cc13fbda</Hash>
</Codenesium>*/