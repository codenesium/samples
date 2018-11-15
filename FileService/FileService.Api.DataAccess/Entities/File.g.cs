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
			int? bucketId,
			DateTime dateCreated,
			string description,
			DateTime expiration,
			string extension,
			Guid externalId,
			double fileSizeInByte,
			int fileTypeId,
			int id,
			string location,
			string privateKey,
			string publicKey)
		{
			this.BucketId = bucketId;
			this.DateCreated = dateCreated;
			this.Description = description;
			this.Expiration = expiration;
			this.Extension = extension;
			this.ExternalId = externalId;
			this.FileSizeInByte = fileSizeInByte;
			this.FileTypeId = fileTypeId;
			this.Id = id;
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
		public virtual double FileSizeInByte { get; private set; }

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
		public virtual Bucket BucketNavigation { get; private set; }

		public void SetBucketNavigation(Bucket item)
		{
			this.BucketNavigation = item;
		}

		[ForeignKey("FileTypeId")]
		public virtual FileType FileTypeNavigation { get; private set; }

		public void SetFileTypeNavigation(FileType item)
		{
			this.FileTypeNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>398a6cb0c0f233c81fff6f04c4591543</Hash>
</Codenesium>*/