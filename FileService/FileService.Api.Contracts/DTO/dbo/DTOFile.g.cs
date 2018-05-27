using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Contracts
{
	public partial class DTOFile: AbstractDTO
	{
		public DTOFile() : base()
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

		public Nullable<int> BucketId { get; set; }
		public DateTime DateCreated { get; set; }
		public string Description { get; set; }
		public DateTime Expiration { get; set; }
		public string Extension { get; set; }
		public Guid ExternalId { get; set; }
		public decimal FileSizeInBytes { get; set; }
		public int FileTypeId { get; set; }
		public int Id { get; set; }
		public string Location { get; set; }
		public string PrivateKey { get; set; }
		public string PublicKey { get; set; }
	}
}

/*<Codenesium>
    <Hash>d5c643020206cafb1e82708c30d880f2</Hash>
</Codenesium>*/