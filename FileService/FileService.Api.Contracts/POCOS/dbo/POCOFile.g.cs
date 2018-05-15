using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FileServiceNS.Api.Contracts
{
	public partial class POCOFile
	{
		public POCOFile()
		{}

		public POCOFile(
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
			this.DateCreated = dateCreated.ToDateTime();
			this.Description = description;
			this.Expiration = expiration.ToDateTime();
			this.Extension = extension;
			this.ExternalId = externalId.ToGuid();
			this.FileSizeInBytes = fileSizeInBytes.ToDecimal();
			this.Id = id.ToInt();
			this.Location = location;
			this.PrivateKey = privateKey;
			this.PublicKey = publicKey;

			this.BucketId = new ReferenceEntity<Nullable<int>>(bucketId,
			                                                   nameof(ApiResponse.Buckets));
			this.FileTypeId = new ReferenceEntity<int>(fileTypeId,
			                                           nameof(ApiResponse.FileTypes));
		}

		public ReferenceEntity<Nullable<int>> BucketId { get; set; }
		public DateTime DateCreated { get; set; }
		public string Description { get; set; }
		public DateTime Expiration { get; set; }
		public string Extension { get; set; }
		public Guid ExternalId { get; set; }
		public decimal FileSizeInBytes { get; set; }
		public ReferenceEntity<int> FileTypeId { get; set; }
		public int Id { get; set; }
		public string Location { get; set; }
		public string PrivateKey { get; set; }
		public string PublicKey { get; set; }

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

		public void DisableAllFields()
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
    <Hash>3461670b2dfd32c4aeddd8dd4e7e68b0</Hash>
</Codenesium>*/