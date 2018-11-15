using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Client
{
	public partial class ApiFileClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int? bucketId,
			DateTime dateCreated,
			string description,
			DateTime expiration,
			string extension,
			Guid externalId,
			double fileSizeInByte,
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
			this.FileSizeInByte = fileSizeInByte;
			this.FileTypeId = fileTypeId;
			this.Location = location;
			this.PrivateKey = privateKey;
			this.PublicKey = publicKey;

			this.BucketIdEntity = nameof(ApiResponse.Buckets);
			this.FileTypeIdEntity = nameof(ApiResponse.FileTypes);
		}

		[JsonProperty]
		public int? BucketId { get; private set; }

		[JsonProperty]
		public string BucketIdEntity { get; set; }

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
		public double FileSizeInByte { get; private set; }

		[JsonProperty]
		public int FileTypeId { get; private set; }

		[JsonProperty]
		public string FileTypeIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Location { get; private set; }

		[JsonProperty]
		public string PrivateKey { get; private set; }

		[JsonProperty]
		public string PublicKey { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1e7d73d78b693f68eba1db4c8f9526a7</Hash>
</Codenesium>*/