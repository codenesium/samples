using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
	public class FileModelValidator: AbstractFileModelValidator, IFileModelValidator
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
    <Hash>c5a17a3abb5d3756181d33e39354a842</Hash>
</Codenesium>*/