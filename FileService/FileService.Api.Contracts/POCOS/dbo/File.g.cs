using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FileServiceNS.Api.Contracts
{
	public partial class POCOFile
	{
		public POCOFile()
		{}

		public POCOFile(Nullable<int> bucketId,
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
			this.ExternalId = externalId;
			this.FileSizeInBytes = fileSizeInBytes.ToDecimal();
			this.Id = id.ToInt();
			this.Location = location;
			this.PrivateKey = privateKey;
			this.PublicKey = publicKey;

			BucketId = new ReferenceEntity<Nullable<int>>(bucketId,
			                                              "Bucket");
			FileTypeId = new ReferenceEntity<int>(fileTypeId,
			                                      "FileType");
		}

		public ReferenceEntity<Nullable<int>>BucketId {get; set;}
		public DateTime DateCreated {get; set;}
		public string Description {get; set;}
		public DateTime Expiration {get; set;}
		public string Extension {get; set;}
		public Guid ExternalId {get; set;}
		public decimal FileSizeInBytes {get; set;}
		public ReferenceEntity<int>FileTypeId {get; set;}
		public int Id {get; set;}
		public string Location {get; set;}
		public string PrivateKey {get; set;}
		public string PublicKey {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBucketIdValue {get; set;} = true;

		public bool ShouldSerializeBucketId()
		{
			return ShouldSerializeBucketIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateCreatedValue {get; set;} = true;

		public bool ShouldSerializeDateCreated()
		{
			return ShouldSerializeDateCreatedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue {get; set;} = true;

		public bool ShouldSerializeDescription()
		{
			return ShouldSerializeDescriptionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExpirationValue {get; set;} = true;

		public bool ShouldSerializeExpiration()
		{
			return ShouldSerializeExpirationValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExtensionValue {get; set;} = true;

		public bool ShouldSerializeExtension()
		{
			return ShouldSerializeExtensionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue {get; set;} = true;

		public bool ShouldSerializeExternalId()
		{
			return ShouldSerializeExternalIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFileSizeInBytesValue {get; set;} = true;

		public bool ShouldSerializeFileSizeInBytes()
		{
			return ShouldSerializeFileSizeInBytesValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFileTypeIdValue {get; set;} = true;

		public bool ShouldSerializeFileTypeId()
		{
			return ShouldSerializeFileTypeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLocationValue {get; set;} = true;

		public bool ShouldSerializeLocation()
		{
			return ShouldSerializeLocationValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePrivateKeyValue {get; set;} = true;

		public bool ShouldSerializePrivateKey()
		{
			return ShouldSerializePrivateKeyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePublicKeyValue {get; set;} = true;

		public bool ShouldSerializePublicKey()
		{
			return ShouldSerializePublicKeyValue;
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
    <Hash>767aa41f1e54239f38a90f401abfb269</Hash>
</Codenesium>*/