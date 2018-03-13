using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FileServiceNS.Api.Contracts
{
	[Table("File", Schema="dbo")]
	public partial class File
	{
		public File()
		{}

		public Nullable<int> bucketId {get; set;}
		public DateTime dateCreated {get; set;}
		public string description {get; set;}
		public DateTime expiration {get; set;}
		public string extension {get; set;}
		public Guid externalId {get; set;}
		public decimal fileSizeInBytes {get; set;}
		public int fileTypeId {get; set;}
		[Key]
		public int id {get; set;}
		public string location {get; set;}
		public string privateKey {get; set;}
		public string publicKey {get; set;}

		[ForeignKey("bucketId")]
		public virtual Bucket BucketRef { get; set; }
		[ForeignKey("fileTypeId")]
		public virtual FileType FileTypeRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>e7cf744b011d0ce1bb9dd00ec68baac3</Hash>
</Codenesium>*/