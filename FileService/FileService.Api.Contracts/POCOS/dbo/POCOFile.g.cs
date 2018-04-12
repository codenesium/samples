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
			int id,
			Guid externalId,
			string privateKey,
			string publicKey,
			string location,
			DateTime expiration,
			string extension,
			DateTime dateCreated,
			decimal fileSizeInBytes,
			int fileTypeId,
			Nullable<int> bucketId,
			string description)
		{
			this.Id = id.ToInt();
			this.ExternalId = externalId;
			this.PrivateKey = privateKey;
			this.PublicKey = publicKey;
			this.Location = location;
			this.Expiration = expiration.ToDateTime();
			this.Extension = extension;
			this.DateCreated = dateCreated.ToDateTime();
			this.FileSizeInBytes = fileSizeInBytes.ToDecimal();
			this.Description = description;

			this.FileTypeId = new ReferenceEntity<int>(fileTypeId,
			                                           "FileType");
			this.BucketId = new ReferenceEntity<Nullable<int>>(bucketId,
			                                                   "Bucket");
		}

		public int Id { get; set; }
		public Guid ExternalId { get; set; }
		public string PrivateKey { get; set; }
		public string PublicKey { get; set; }
		public string Location { get; set; }
		public DateTime Expiration { get; set; }
		public string Extension { get; set; }
		public DateTime DateCreated { get; set; }
		public decimal FileSizeInBytes { get; set; }
		public ReferenceEntity<int> FileTypeId { get; set; }
		public ReferenceEntity<Nullable<int>> BucketId { get; set; }
		public string Description { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue { get; set; } = true;

		public bool ShouldSerializeExternalId()
		{
			return this.ShouldSerializeExternalIdValue;
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

		[JsonIgnore]
		public bool ShouldSerializeLocationValue { get; set; } = true;

		public bool ShouldSerializeLocation()
		{
			return this.ShouldSerializeLocationValue;
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
		public bool ShouldSerializeDateCreatedValue { get; set; } = true;

		public bool ShouldSerializeDateCreated()
		{
			return this.ShouldSerializeDateCreatedValue;
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
		public bool ShouldSerializeBucketIdValue { get; set; } = true;

		public bool ShouldSerializeBucketId()
		{
			return this.ShouldSerializeBucketIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue { get; set; } = true;

		public bool ShouldSerializeDescription()
		{
			return this.ShouldSerializeDescriptionValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeExternalIdValue = false;
			this.ShouldSerializePrivateKeyValue = false;
			this.ShouldSerializePublicKeyValue = false;
			this.ShouldSerializeLocationValue = false;
			this.ShouldSerializeExpirationValue = false;
			this.ShouldSerializeExtensionValue = false;
			this.ShouldSerializeDateCreatedValue = false;
			this.ShouldSerializeFileSizeInBytesValue = false;
			this.ShouldSerializeFileTypeIdValue = false;
			this.ShouldSerializeBucketIdValue = false;
			this.ShouldSerializeDescriptionValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>1d92adcc98f65ce53f38fb28b739d60a</Hash>
</Codenesium>*/