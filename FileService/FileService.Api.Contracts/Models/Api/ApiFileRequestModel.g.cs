using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
        public partial class ApiFileRequestModel : AbstractApiRequestModel
        {
                public ApiFileRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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
                }

                [JsonProperty]
                public int? BucketId { get; private set; }

                [JsonProperty]
                public DateTime DateCreated { get; private set; }

                [JsonProperty]
                public string Description { get; private set; }

                [JsonProperty]
                public DateTime Expiration { get; private set; }

                [JsonProperty]
                public string Extension { get; private set; }

                [JsonProperty]
                public Guid ExternalId { get; private set; }

                [JsonProperty]
                public decimal FileSizeInBytes { get; private set; }

                [JsonProperty]
                public int FileTypeId { get; private set; }

                [JsonProperty]
                public string Location { get; private set; }

                [JsonProperty]
                public string PrivateKey { get; private set; }

                [JsonProperty]
                public string PublicKey { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d336cc4b82a9181b90fe985c873ed0e3</Hash>
</Codenesium>*/