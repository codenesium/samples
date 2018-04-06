using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FileServiceNS.Api.Contracts
{
	[Table("File", Schema="dbo")]
	public partial class EFFile
	{
		public EFFile()
		{}

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

		[ForeignKey("FileTypeId")]
		public virtual EFFileType FileTypeRef { get; set; }
		[ForeignKey("BucketId")]
		public virtual EFBucket BucketRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>e02bfb769cb9cbceca3c8a4bf8206901</Hash>
</Codenesium>*/