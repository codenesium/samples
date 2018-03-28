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
		public int id {get; set;}
		public Guid externalId {get; set;}
		public string privateKey {get; set;}
		public string publicKey {get; set;}
		public string location {get; set;}
		public DateTime expiration {get; set;}
		public string extension {get; set;}
		public DateTime dateCreated {get; set;}
		public decimal fileSizeInBytes {get; set;}
		public int fileTypeId {get; set;}
		public Nullable<int> bucketId {get; set;}
		public string description {get; set;}

		[ForeignKey("fileTypeId")]
		public virtual EFFileType FileTypeRef { get; set; }
		[ForeignKey("bucketId")]
		public virtual EFBucket BucketRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>aa701b47bdb2a70b8d5f898b2b49f478</Hash>
</Codenesium>*/