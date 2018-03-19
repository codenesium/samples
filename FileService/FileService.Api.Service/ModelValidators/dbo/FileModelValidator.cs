using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
	public class FileModelValidator: AbstractFileModelValidator,IFileModelValidator
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
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
		}
	}
}

/*<Codenesium>
    <Hash>511a44e808df8cc7b27798f02394f962</Hash>
</Codenesium>*/