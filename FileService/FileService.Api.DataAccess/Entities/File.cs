using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
        [Table("File", Schema="dbo")]
        public partial class File:AbstractEntity
        {
                public File()
                {
                }

                public void SetProperties(
                        Nullable<int> bucketId,
                        DateTime dateCreated,
                        string description,
                        DateTime expiration,
                        string extension,
                        Guid externalId,
                        decimal fileSizeInBytes,
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
                        this.FileSizeInBytes = fileSizeInBytes;
                        this.FileTypeId = fileTypeId;
                        this.Id = id;
                        this.Location = location;
                        this.PrivateKey = privateKey;
                        this.PublicKey = publicKey;
                }

                [Column("bucketId", TypeName="int")]
                public Nullable<int> BucketId { get; private set; }

                [Column("dateCreated", TypeName="datetime")]
                public DateTime DateCreated { get; private set; }

                [Column("description", TypeName="nvarchar(255)")]
                public string Description { get; private set; }

                [Column("expiration", TypeName="datetime")]
                public DateTime Expiration { get; private set; }

                [Column("extension", TypeName="varchar(32)")]
                public string Extension { get; private set; }

                [Column("externalId", TypeName="uniqueidentifier")]
                public Guid ExternalId { get; private set; }

                [Column("fileSizeInBytes", TypeName="decimal")]
                public decimal FileSizeInBytes { get; private set; }

                [Column("fileTypeId", TypeName="int")]
                public int FileTypeId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("location", TypeName="varchar(255)")]
                public string Location { get; private set; }

                [Column("privateKey", TypeName="varchar(64)")]
                public string PrivateKey { get; private set; }

                [Column("publicKey", TypeName="varchar(64)")]
                public string PublicKey { get; private set; }

                [ForeignKey("BucketId")]
                public virtual Bucket Bucket { get; set; }

                [ForeignKey("FileTypeId")]
                public virtual FileType FileType { get; set; }
        }
}

/*<Codenesium>
    <Hash>4721eb31882397050f212c8920add05f</Hash>
</Codenesium>*/