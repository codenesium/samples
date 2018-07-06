using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
        public partial class ApiFileResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int? bucketId,
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
                        this.Id = id;
                        this.BucketId = bucketId;
                        this.DateCreated = dateCreated;
                        this.Description = description;
                        this.Expiration = expiration;
                        this.Extension = extension;
                        this.ExternalId = externalId;
                        this.FileSizeInBytes = fileSizeInBytes;
                        this.FileTypeId = fileTypeId;
                        this.Location = location;
                        this.PrivateKey = privateKey;
                        this.PublicKey = publicKey;

                        this.BucketIdEntity = nameof(ApiResponse.Buckets);
                        this.FileTypeIdEntity = nameof(ApiResponse.FileTypes);
                }

                public int? BucketId { get; private set; }

                public string BucketIdEntity { get; set; }

                public DateTime DateCreated { get; private set; }

                public string Description { get; private set; }

                public DateTime Expiration { get; private set; }

                public string Extension { get; private set; }

                public Guid ExternalId { get; private set; }

                public decimal FileSizeInBytes { get; private set; }

                public int FileTypeId { get; private set; }

                public string FileTypeIdEntity { get; set; }

                public int Id { get; private set; }

                public string Location { get; private set; }

                public string PrivateKey { get; private set; }

                public string PublicKey { get; private set; }
        }
}

/*<Codenesium>
    <Hash>97d3bc093a1c74969db568cd6fa61ff3</Hash>
</Codenesium>*/