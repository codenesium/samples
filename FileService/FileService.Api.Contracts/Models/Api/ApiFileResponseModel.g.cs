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

                [Required]
                [JsonProperty]
                public int? BucketId { get; private set; }

                [JsonProperty]
                public string BucketIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public DateTime DateCreated { get; private set; }

                [Required]
                [JsonProperty]
                public string Description { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime Expiration { get; private set; }

                [Required]
                [JsonProperty]
                public string Extension { get; private set; }

                [Required]
                [JsonProperty]
                public Guid ExternalId { get; private set; }

                [Required]
                [JsonProperty]
                public decimal FileSizeInBytes { get; private set; }

                [Required]
                [JsonProperty]
                public int FileTypeId { get; private set; }

                [JsonProperty]
                public string FileTypeIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Location { get; private set; }

                [Required]
                [JsonProperty]
                public string PrivateKey { get; private set; }

                [Required]
                [JsonProperty]
                public string PublicKey { get; private set; }
        }
}

/*<Codenesium>
    <Hash>85b7b3fca82ac79266318e3492caa922</Hash>
</Codenesium>*/