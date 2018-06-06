using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Services
{
	public partial class BOFile:AbstractBusinessObject
	{
		public BOFile() : base()
		{}

		public void SetProperties(int id,
		                          Nullable<int> bucketId,
		                          DateTime dateCreated,
		                          string description,
		                          DateTime expiration,
		                          string extension,
		                          Guid externalId,
		                          decimal fileSizeInBytes,
		                          int fileTypeId,
		                          string location,
		                          string privateKey,
		                          string publicKey)
		{
			this.BucketId = bucketId.ToNullableInt();
			this.DateCreated = dateCreated.ToDateTime();
			this.Description = description;
			this.Expiration = expiration.ToDateTime();
			this.Extension = extension;
			this.ExternalId = externalId.ToGuid();
			this.FileSizeInBytes = fileSizeInBytes.ToDecimal();
			this.FileTypeId = fileTypeId.ToInt();
			this.Id = id.ToInt();
			this.Location = location;
			this.PrivateKey = privateKey;
			this.PublicKey = publicKey;
		}

		public Nullable<int> BucketId { get; private set; }
		public DateTime DateCreated { get; private set; }
		public string Description { get; private set; }
		public DateTime Expiration { get; private set; }
		public string Extension { get; private set; }
		public Guid ExternalId { get; private set; }
		public decimal FileSizeInBytes { get; private set; }
		public int FileTypeId { get; private set; }
		public int Id { get; private set; }
		public string Location { get; private set; }
		public string PrivateKey { get; private set; }
		public string PublicKey { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2e546fb85592d6bd36f093882c47cdee</Hash>
</Codenesium>*/