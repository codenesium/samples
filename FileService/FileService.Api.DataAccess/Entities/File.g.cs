using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FileServiceNS.Api.DataAccess
{
	[Table("File", Schema="dbo")]
	public partial class File : AbstractEntity
	{
		public File()
		{
		}

		public virtual void SetProperties(
			int id,
			int? bucketId,
			DateTime dateCreated,
			string description,
			DateTime expiration,
			string extension,
			Guid externalId,
			decimal fileSizeInByte,
			int fileTypeId,
			string location,
			string privateKey,
			string publicKey)
		{
			this.Id = id;
			this.BucketId = bucketId;
			this.DateCreated = dateCreated;
			this.Description = description;
			this.Expiration = expiration;
			this.Extension = extension;
			this.ExternalId = externalId;
			this.FileSizeInByte = fileSizeInByte;
			this.FileTypeId = fileTypeId;
			this.Location = location;
			this.PrivateKey = privateKey;
			this.PublicKey = publicKey;
		}

		[Column("bucketId")]
		public virtual int? BucketId { get; private set; }

		[Column("dateCreated")]
		public virtual DateTime DateCreated { get; private set; }

		[MaxLength(255)]
		[Column("description")]
		public virtual string Description { get; private set; }

		[Column("expiration")]
		public virtual DateTime Expiration { get; private set; }

		[MaxLength(32)]
		[Column("extension")]
		public virtual string Extension { get; private set; }

		[Column("externalId")]
		public virtual Guid ExternalId { get; private set; }

		[Column("fileSizeInBytes")]
		public virtual decimal FileSizeInByte { get; private set; }

		[Column("fileTypeId")]
		public virtual int FileTypeId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(255)]
		[Column("location")]
		public virtual string Location { get; private set; }

		[MaxLength(64)]
		[Column("privateKey")]
		public virtual string PrivateKey { get; private set; }

		[MaxLength(64)]
		[Column("publicKey")]
		public virtual string PublicKey { get; private set; }

		[ForeignKey("BucketId")]
		public virtual Bucket BucketIdNavigation { get; private set; }

		public void SetBucketIdNavigation(Bucket item)
		{
			this.BucketIdNavigation = item;
		}

		[ForeignKey("FileTypeId")]
		public virtual FileType FileTypeIdNavigation { get; private set; }

		public void SetFileTypeIdNavigation(FileType item)
		{
			this.FileTypeIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>1879759c5a8c815492e5b196dc8e64a0</Hash>
</Codenesium>*/