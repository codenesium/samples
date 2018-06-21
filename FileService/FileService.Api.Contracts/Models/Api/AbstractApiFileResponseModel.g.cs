using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
        public abstract class AbstractApiFileResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
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

                        this.BucketIdEntity = nameof(ApiResponse.Buckets);
                        this.FileTypeIdEntity = nameof(ApiResponse.FileTypes);
                }

                public Nullable<int> BucketId { get; private set; }

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
                public bool ShouldSerializeBucketIdValue { get; set; } = false;

                public bool ShouldSerializeBucketId()
                {
                        return this.ShouldSerializeBucketIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDateCreatedValue { get; set; } = false;

                public bool ShouldSerializeDateCreated()
                {
                        return this.ShouldSerializeDateCreatedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDescriptionValue { get; set; } = false;

                public bool ShouldSerializeDescription()
                {
                        return this.ShouldSerializeDescriptionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExpirationValue { get; set; } = false;

                public bool ShouldSerializeExpiration()
                {
                        return this.ShouldSerializeExpirationValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExtensionValue { get; set; } = false;

                public bool ShouldSerializeExtension()
                {
                        return this.ShouldSerializeExtensionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExternalIdValue { get; set; } = false;

                public bool ShouldSerializeExternalId()
                {
                        return this.ShouldSerializeExternalIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFileSizeInBytesValue { get; set; } = false;

                public bool ShouldSerializeFileSizeInBytes()
                {
                        return this.ShouldSerializeFileSizeInBytesValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFileTypeIdValue { get; set; } = false;

                public bool ShouldSerializeFileTypeId()
                {
                        return this.ShouldSerializeFileTypeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = false;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLocationValue { get; set; } = false;

                public bool ShouldSerializeLocation()
                {
                        return this.ShouldSerializeLocationValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePrivateKeyValue { get; set; } = false;

                public bool ShouldSerializePrivateKey()
                {
                        return this.ShouldSerializePrivateKeyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePublicKeyValue { get; set; } = false;

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
    <Hash>ad0e9a3f14fdcfc76fd5bbbf015c0e03</Hash>
</Codenesium>*/