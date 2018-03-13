using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
	public class FileModelValidator: FileModelValidatorAbstract
	{
		public FileModelValidator()
		{   }

		public void CreateMode()
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.IdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
		}

		public void UpdateMode()
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.IdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
		}

		public void PatchMode()
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.IdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
		}
	}
}

/*<Codenesium>
    <Hash>bd37b79be452997aa80aef7a33f09b20</Hash>
</Codenesium>*/