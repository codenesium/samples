using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
	[Table("File", Schema="dbo")]
	public partial class File:AbstractEntityFrameworkPOCO
	{
		public File()
		{}

		public void SetProperties(
			int id,
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

		[Column("bucketId", TypeName="int")]
		public Nullable<int> BucketId { get; set; }

		[Column("dateCreated", TypeName="datetime")]
		public DateTime DateCreated { get; set; }

		[Column("description", TypeName="nvarchar(255)")]
		public string Description { get; set; }

		[Column("expiration", TypeName="datetime")]
		public DateTime Expiration { get; set; }

		[Column("extension", TypeName="varchar(32)")]
		public string Extension { get; set; }

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId { get; set; }

		[Column("fileSizeInBytes", TypeName="decimal")]
		public decimal FileSizeInBytes { get; set; }

		[Column("fileTypeId", TypeName="int")]
		public int FileTypeId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("location", TypeName="varchar(255)")]
		public string Location { get; set; }

		[Column("privateKey", TypeName="varchar(64)")]
		public string PrivateKey { get; set; }

		[Column("publicKey", TypeName="varchar(64)")]
		public string PublicKey { get; set; }

		[ForeignKey("BucketId")]
		public virtual Bucket Bucket { get; set; }

		[ForeignKey("FileTypeId")]
		public virtual FileType FileType { get; set; }
	}
}

/*<Codenesium>
    <Hash>ec35e393287bcc5d04ef0403e4c7de4f</Hash>
</Codenesium>*/