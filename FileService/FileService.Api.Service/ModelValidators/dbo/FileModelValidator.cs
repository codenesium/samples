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
		}

		public void UpdateMode()
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
		}

		public void PatchMode()
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
		}
	}
}

/*<Codenesium>
    <Hash>da9aa4e9f1f2a26c0bbdde5576c5bf6d</Hash>
</Codenesium>*/