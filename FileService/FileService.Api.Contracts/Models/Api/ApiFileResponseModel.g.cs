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

                [JsonIgnore]
                public bool ShouldSerializeBucketIdValue { get; set; } = true;

                public bool ShouldSerializeBucketId()
                {
                        return this.ShouldSerializeBucketIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDateCreatedValue { get; set; } = true;

                public bool ShouldSerializeDateCreated()
                {
                        return this.ShouldSerializeDateCreatedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDescriptionValue { get; set; } = true;

                public bool ShouldSerializeDescription()
                {
                        return this.ShouldSerializeDescriptionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExpirationValue { get; set; } = true;

                public bool ShouldSerializeExpiration()
                {
                        return this.ShouldSerializeExpirationValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExtensionValue { get; set; } = true;

                public bool ShouldSerializeExtension()
                {
                        return this.ShouldSerializeExtensionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExternalIdValue { get; set; } = true;

                public bool ShouldSerializeExternalId()
                {
                        return this.ShouldSerializeExternalIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFileSizeInBytesValue { get; set; } = true;

                public bool ShouldSerializeFileSizeInBytes()
                {
                        return this.ShouldSerializeFileSizeInBytesValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFileTypeIdValue { get; set; } = true;

                public bool ShouldSerializeFileTypeId()
                {
                        return this.ShouldSerializeFileTypeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLocationValue { get; set; } = true;

                public bool ShouldSerializeLocation()
                {
                        return this.ShouldSerializeLocationValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePrivateKeyValue { get; set; } = true;

                public bool ShouldSerializePrivateKey()
                {
                        return this.ShouldSerializePrivateKeyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePublicKeyValue { get; set; } = true;

                public bool ShouldSerializePublicKey()
                {
                        return this.ShouldSerializePublicKeyValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBucketIdValue = false;
                        this.ShouldSerializeDateCreatedValue = false;
                        this.ShouldSerializeDescriptionValue = false;
                        this.ShouldSerializeExpirationValue = false;
                        this.ShouldSerializeExtensionValue = false;
                        this.ShouldSerializeExternalIdValue = false;
                        this.ShouldSerializeFileSizeInBytesValue = false;
                        this.ShouldSerializeFileTypeIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLocationValue = false;
                        this.ShouldSerializePrivateKeyValue = false;
                        this.ShouldSerializePublicKeyValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>2ad922f7d2c2443f2aace72f4c4bf827</Hash>
</Codenesium>*/