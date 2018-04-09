using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace FileServiceNS.Api.Contracts
{
	[Table("File", Schema="dbo")]
	public partial class EFFile
	{
		public EFFile()
		{}

		public void SetProperties(int id,
		                          Guid externalId,
		                          string privateKey,
		                          string publicKey,
		                          string location,
		                          DateTime expiration,
		                          string extension,
		                          DateTime dateCreated,
		                          decimal fileSizeInBytes,
		                          int fileTypeId,
		                          Nullable<int> bucketId,
		                          string description)
		{
			this.Id = id.ToInt();
			this.ExternalId = externalId;
			this.PrivateKey = privateKey;
			this.PublicKey = publicKey;
			this.Location = location;
			this.Expiration = expiration.ToDateTime();
			this.Extension = extension;
			this.DateCreated = dateCreated.ToDateTime();
			this.FileSizeInBytes = fileSizeInBytes.ToDecimal();
			this.FileTypeId = fileTypeId.ToInt();
			this.BucketId = bucketId.ToNullableInt();
			this.Description = description;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId {get; set;}

		[Column("privateKey", TypeName="varchar(64)")]
		public string PrivateKey {get; set;}

		[Column("publicKey", TypeName="varchar(64)")]
		public string PublicKey {get; set;}

		[Column("location", TypeName="varchar(255)")]
		public string Location {get; set;}

		[Column("expiration", TypeName="datetime")]
		public DateTime Expiration {get; set;}

		[Column("extension", TypeName="varchar(32)")]
		public string Extension {get; set;}

		[Column("dateCreated", TypeName="datetime")]
		public DateTime DateCreated {get; set;}

		[Column("fileSizeInBytes", TypeName="decimal")]
		public decimal FileSizeInBytes {get; set;}

		[Column("fileTypeId", TypeName="int")]
		public int FileTypeId {get; set;}

		[Column("bucketId", TypeName="int")]
		public Nullable<int> BucketId {get; set;}

		[Column("description", TypeName="nvarchar(255)")]
		public string Description {get; set;}

		public virtual EFFileType FileType { get; set; }

		public virtual EFBucket Bucket { get; set; }
	}
}

/*<Codenesium>
    <Hash>ac9f5471fc98568e616527d9b5c3c5d2</Hash>
</Codenesium>*/