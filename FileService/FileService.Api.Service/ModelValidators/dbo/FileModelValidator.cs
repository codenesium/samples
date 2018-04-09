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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>5fa5737a86a815dcc505900d1197914c</Hash>
</Codenesium>*/